using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Data.Dtos.UsuarioDtos;
using UsuariosApi.Models;
using System.Linq;

namespace UsuariosApi.Services
{
    public class UsuarioService
    {
        private IMapper _mapper;
        private UserManager<Usuario> _userManager;
        private SignInManager<Usuario> _signInManager;
        private TokenService _tokenService;

        public UsuarioService(UserManager<Usuario> userManager, IMapper mapper, SignInManager<Usuario> signInManager, TokenService tokenService)
        {
            _userManager=userManager;
            _mapper=mapper;
            _signInManager=signInManager;
            _tokenService=tokenService;
        }

        public async Task<IdentityResult> Cadastra(CreateUsuarioDto createUsuarioDto)
        {
            Usuario usuario = _mapper.Map<Usuario>(createUsuarioDto);
            IdentityResult resultado = await _userManager.CreateAsync(usuario, createUsuarioDto.Senha);

            // Retorne o resultado para que o controller possa analisar e responder apropriadamente
            return resultado;
        }

        public async Task<string> Login(LoginUsuarioDto dto)
        {
            var resultado = await _signInManager.PasswordSignInAsync(dto.Username, dto.Senha, false, false);



            var usuario = _signInManager
                .UserManager
                .Users
                .FirstOrDefault(u => u.NormalizedUserName == dto.Username.ToUpper());

            var token = _tokenService.GenerateToken(usuario);

            if (resultado.Succeeded)
            {
                return token;
            }
            else if (resultado.IsLockedOut)
            {
                return "Usuário bloqueado.";
            }
            else if (resultado.IsNotAllowed)
            {
                return "Não é permitido login.";
            }
            else if (resultado.RequiresTwoFactor)
            {
                return "É necessário autenticação de dois fatores.";
            }
            else
            {
                return "Usuário ou senha inválidos.";
            }
        }

    }
}
