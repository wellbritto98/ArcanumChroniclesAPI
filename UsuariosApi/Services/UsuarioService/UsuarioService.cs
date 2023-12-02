using System;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Data.Dtos.EmailDto;
using UsuariosApi.Data.Dtos.UsuarioDtos;
using UsuariosApi.Models;

namespace UsuariosApi.Services.Usuario
{
    public class UsuarioService
    {
        private IMapper _mapper;
        private UserManager<UsuariosApi.Models.Usuario> _userManager;
        private SignInManager<UsuariosApi.Models.Usuario> _signInManager;
        private TokenService _tokenService;
        private readonly EmailService.EmailService _emailService;
        private IHttpContextAccessor _httpContextAccessor;

        public UsuarioService(IMapper mapper, UserManager<UsuariosApi.Models.Usuario> userManager,
            SignInManager<UsuariosApi.Models.Usuario> signInManager, TokenService tokenService,
            EmailService.EmailService emailService, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _emailService = emailService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiResponse> EnviaEmailVerificacao(string email)
        {
            var usuario = await _userManager.FindByEmailAsync(email);
            if (usuario == null)
            {
                return new ApiResponse { Success = false, Message = "Usuário não encontrado!" };
            }

            var dto = new EmailDto();
            dto.To = usuario.Email;
            dto.Subject = "Clique no link de verificaçao para confirmar seu email";
            string webProtocol = _httpContextAccessor.HttpContext.Request.IsHttps ? "https://" : "http://";
            var host = _httpContextAccessor.HttpContext.Request.Host;
            dto.Body = $"{webProtocol}{host}/api/Usuario/VerificarEmail?token={usuario.VerificationToken}";
            _emailService.EnviarEmail(dto);
            return new ApiResponse { Success = true, Message = "Email enviado com sucesso!" };
        }

        public async Task<ApiResponse> EnviaEmailResetarSenha(string email)
        {
            var usuario = await _userManager.FindByEmailAsync(email);
            if (usuario == null)
            {
                return new ApiResponse { Success = false, Message = "Usuário não encontrado!" };
            }

            var dto = new EmailDto();
            dto.To = usuario.Email;
            dto.Subject = "Clique no link para resetar sua senha";

            dto.Body =
                $"Acesse o link: http://localhost:3000/resetar-senha e no formulario, informe seu token de resetar senha: {usuario.PasswordResetToken}";
            _emailService.EnviarEmail(dto);
            return new ApiResponse { Success = true, Message = "Email enviado com sucesso!" };
        }

        //cadastrar usuario
        public async Task<ApiResponse> CadastraUsuario(CreateUsuarioDto dto)
        {
            UsuariosApi.Models.Usuario usuario = _mapper.Map<UsuariosApi.Models.Usuario>(dto);
            usuario.UserName = usuario.Email;
            usuario.RegisteredAt = DateTime.UtcNow;
            usuario.VerificationToken = CreateRandomToken();
            usuario.VerificationTokenExpires = DateTime.UtcNow.AddDays(7);
            usuario.Role = "player";
            var today = DateTime.Today;
            var age = today.Year - usuario.DataNascimento.Year;

            // Ajusta a idade se o aniversário ainda não ocorreu este ano
            if (usuario.DataNascimento.Date > today.AddYears(-age)) age--;

            if (age < 18)
            {
                return new ApiResponse { Success = false, Message = "Usuário menor de idade!" };
            }


            if (!dto.AceitaTermos)
            {
                return new ApiResponse
                {
                    Success = false,
                    Message = "Infelizmente só podemos cadastrar usuários que aceitam os termos de uso."
                };
            }

            else
            {
                IdentityResult resultado = await _userManager.CreateAsync(usuario, dto.Senha);

                if (!resultado.Succeeded)
                {
                    var errors = resultado.Errors.Select(e => e.Description);
                    return new ApiResponse
                        { Success = false, Message = $"Falha ao cadastrar usuário: {string.Join(", ", errors)}" };
                }

                await EnviaEmailVerificacao(usuario.Email);
                return new ApiResponse
                {
                    Success = true,
                    Message = "Usuário cadastrado com sucesso! Verifique sua conta no link que enviamos por email"
                };
            }
        }

        //Fazer login
        public async Task<ApiResponse> Login(LoginUsuarioDto dto)
        {
            var resultado = await _signInManager.PasswordSignInAsync(dto.Email, dto.Senha, false, false);


            if (!resultado.Succeeded)
            {
                return new ApiResponse { Success = false, Message = "Usuário ou senha incorretos." };
            }


            var usuario = await _userManager.FindByEmailAsync(dto.Email);

            if (usuario.VerifiedAt == null)
            {
                return new ApiResponse { Success = false, Message = "Email não verificado!" };
            }


            if (usuario != null)
            {
                usuario.LastLoginAt = DateTime.UtcNow;
                await _userManager.UpdateAsync(usuario); // Atualiza o usuário no banco de dados
            }
            else
            {
                return new ApiResponse { Success = false, Message = "Usuário não encontrado!" };
            }

            var token = _tokenService.GenerateToken(usuario);

            var response = new LoginResponse
            {
                Token = token,
                hasCharacter = usuario.hasCharacter
            };

            return new ApiResponse { Success = true, Message = "Login bem-sucedido!", Data = response };
        }

        //consultar usuario
        public async Task<IEnumerable<object>> Consultar()
        {
            var usuarios = await _userManager.Users.ToListAsync();
            var usuariosFormatados = usuarios.Select(u => new
            {
                u.Id,
                u.Email,
                u.DataNascimento,
                u.RegisteredAt,
                u.LastLoginAt
            });

            return usuariosFormatados;
        }

        //consultar usuario por ID
        public async Task<object> ConsultarPorId(string id)
        {
            var usuario = await _userManager.FindByIdAsync(id);
            var usuarioFormatado = new
            {
                usuario.Id,
                usuario.Email,
                usuario.DataNascimento,
                usuario.RegisteredAt,
                usuario.LastLoginAt
            };

            return usuarioFormatado;
        }

        public async Task<ApiResponse> VerificarEmail(string token)
        {
            var usuario = await _userManager.Users.FirstOrDefaultAsync(u => u.VerificationToken == token);

            if (usuario == null)
            {
                return new ApiResponse { Success = false, Message = "Token Invalido ou usuario não encontrado!" };
            }

            usuario.VerifiedAt = DateTime.UtcNow;
            usuario.VerificationToken = null;
            usuario.VerificationTokenExpires = null;
            await _userManager.UpdateAsync(usuario);

            return new ApiResponse { Success = true, Message = "Email Verificado !" };
        }

        //esqueci minha senha
        public async Task<ApiResponse> EsqueciMinhaSenha(string email)
        {
            var usuario = await _userManager.FindByEmailAsync(email);

            if (usuario == null)
            {
                return new ApiResponse { Success = false, Message = "Usuário não encontrado!" };
            }

            usuario.PasswordResetToken = CreateRandomToken();
            usuario.ResetTokenExpires = DateTime.UtcNow.AddHours(2);
            await _userManager.UpdateAsync(usuario);

            await EnviaEmailResetarSenha(usuario.Email);


            return new ApiResponse { Success = true, Message = "Token de resetar senha gerado e enviado por email !" };
        }

        //resetar senha
        public async Task<ApiResponse> ResetarSenha(ResetPasswordDto dto)
        {
            var usuario = await _userManager.Users.FirstOrDefaultAsync(u =>
                u.PasswordResetToken == dto.Token && u.ResetTokenExpires > DateTime.UtcNow);

            if (usuario == null || usuario.ResetTokenExpires < DateTime.Now)
            {
                return new ApiResponse { Success = false, Message = "Token Invalido ou expirado!" };
            }

            if (usuario.PasswordHash == dto.Senha)
            {
                return new ApiResponse { Success = false, Message = "A nova senha não pode ser igual a antiga!" };
            }


            IdentityResult resultado = await _userManager.ResetPasswordAsync(usuario, dto.Token, dto.Senha);
            usuario.ResetTokenExpires = null;
            await _userManager.UpdateAsync(usuario);

            return new ApiResponse { Success = true, Message = "Senha resetada com sucesso!" };
        }

        public async Task AlterarRoleUsuario(ChangeUserRoleDto dto)
        {
            var usuario = await _userManager.FindByEmailAsync(dto.Email);

            if (usuario == null)
            {
                throw new ApplicationException("Usuário não encontrado.");
            }

            if (dto.Role == "admin")
            {
                usuario.Role = "admin";
                await _userManager.UpdateAsync(usuario);
            }
            else if (dto.Role == "player")
            {
                usuario.Role = "player";
                await _userManager.UpdateAsync(usuario);
            }
            else
            {
                throw new ApplicationException("Role inválida.");
            }
        }

        public async Task<ApiResponse> VerificaJWTUsuario(string token)
        {
            var verify = _tokenService.VerificaSeTokenJWTEValido(token);

            if (verify == false)
            {
                return new ApiResponse { Success = false, Message = "Token inválido!" };
            }
            else
            {
                return new ApiResponse { Success = true, Message = "Token válido!" };
            }
        }


        private string CreateRandomToken()
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
        }
    }
}