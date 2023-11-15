using System;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Data.Dtos.UsuarioDtos;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class UsuarioService
    {
        private IMapper _mapper;
        private UserManager<Usuario> _userManager;
        private SignInManager<Usuario> _signInManager;
        private TokenService _tokenService;

        public UsuarioService(IMapper mapper, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, TokenService tokenService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }
        
        //cadastrar usuario
        public async Task CadastraUsuario(CreateUsuarioDto dto)
        {
            Usuario usuario = _mapper.Map<Usuario>(dto);
            usuario.UserName = usuario.Email;
            usuario.RegisteredAt = DateTime.UtcNow;
            usuario.VerificationToken = CreateRandomToken();
            usuario.VerificationTokenExpires = DateTime.UtcNow.AddDays(7);
            usuario.Role="player";
            var today = DateTime.Today;
            var age = today.Year - usuario.DataNascimento.Year;

            // Ajusta a idade se o aniversário ainda não ocorreu este ano
            if (usuario.DataNascimento.Date > today.AddYears(-age)) age--;

            if (age < 18)
            {
                throw new ApplicationException("Usuário menor de idade!");
            }
            else
            {
                IdentityResult resultado = await _userManager.CreateAsync(usuario, dto.Senha);

                if (!resultado.Succeeded)
                {
                    var errors = resultado.Errors.Select(e => e.Description);
                    throw new ApplicationException($"Falha ao cadastrar usuário: {string.Join(", ", errors)}");
                }

            }
        }

        //Fazer login
        public async Task<string> Login(LoginUsuarioDto dto)
        {
            var resultado = await _signInManager.PasswordSignInAsync(dto.Email, dto.Senha, false, false);

            if (!resultado.Succeeded)
            {
                throw new ApplicationException("Usuário não autenticado!");
            }



            var usuario = await _userManager.FindByEmailAsync(dto.Email);

            if (usuario.VerifiedAt == null)
            {
                throw new ApplicationException("Email não verificado!");
            }



            if (usuario != null)
            {
                usuario.LastLoginAt = DateTime.UtcNow;
                await _userManager.UpdateAsync(usuario); // Atualiza o usuário no banco de dados
            }
            else
            {
                throw new ApplicationException("Usuário não encontrado!");
            }

            var token = _tokenService.GenerateToken(usuario);

            return token;
        }

        //consultar usuario
        public async Task<IEnumerable<object>> Consultar()
        {
            var usuarios = await _userManager.Users.ToListAsync();
            var usuariosFormatados = usuarios.Select(u => new
            {
                Id = u.Id,
                Email = u.Email,
                DataNascimento = u.DataNascimento,
                RegisteredAt = u.RegisteredAt,
                LastLoginAt = u.LastLoginAt
            });

            return usuariosFormatados;
        }

        //consultar usuario por ID
        public async Task<object> ConsultarPorId(string id)
        {
            var usuario = await _userManager.FindByIdAsync(id);
            var usuarioFormatado = new
            {
                Id = usuario.Id,
                Email = usuario.Email,
                DataNascimento = usuario.DataNascimento,
                RegisteredAt = usuario.RegisteredAt,
                LastLoginAt = usuario.LastLoginAt
            };

            return usuarioFormatado;
        }

        //verificar email
        public async Task<string> VerificarEmail(string token)
        {
            var usuario = await _userManager.Users.FirstOrDefaultAsync(u => u.VerificationToken == token);

            if (usuario == null)
            {
                throw new ApplicationException("Token inválido ou usuário não encontrado.");
            }

            usuario.VerifiedAt = DateTime.UtcNow;
            usuario.VerificationToken = null;
            usuario.VerificationTokenExpires = null;
            await _userManager.UpdateAsync(usuario);
            string resposta = "verificado!";

            return resposta;
        }

        //esqueci minha senha
        public async Task<string> EsqueciMinhaSenha(string email)
        {
            var usuario = await _userManager.FindByEmailAsync(email);

            if (usuario == null)
            {
                throw new ApplicationException("Usuário não encontrado.");
            }

            usuario.PasswordResetToken = CreateRandomToken();
            usuario.ResetTokenExpires = DateTime.UtcNow.AddHours(2);
            await _userManager.UpdateAsync(usuario);

            string resposta = "token de reset gerado";

            return resposta;
        }

        //resetar senha
        public async Task ResetarSenha(ResetPasswordDto dto)
        {
            var usuario = await _userManager.Users.FirstOrDefaultAsync(u => u.PasswordResetToken == dto.Token && u.ResetTokenExpires > DateTime.UtcNow);

            if (usuario == null || usuario.ResetTokenExpires<DateTime.Now)
            {
                throw new ApplicationException("Token inválido ou expirado.");
            }

            if (usuario.PasswordHash == dto.Senha)
            {
                throw new ApplicationException("A nova senha não pode ser igual à senha antiga.");
            }


            IdentityResult resultado = await _userManager.ResetPasswordAsync(usuario, dto.Token, dto.Senha);
            usuario.ResetTokenExpires = null;
            await _userManager.UpdateAsync(usuario);
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
        


        private string CreateRandomToken()
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
        }


    }
}
