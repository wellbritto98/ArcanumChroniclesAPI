using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Data.Dtos.UsuarioDtos;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase
    {
        private UsuarioService _usuarioService;

        public UsuarioController(UsuarioService cadastroService)
        {
            _usuarioService = cadastroService;
        }

        [HttpPost("cadastro")]
        public async Task<IActionResult> CadastraUsuario
            (CreateUsuarioDto dto)
        {
            await _usuarioService.CadastraUsuario(dto);
            return Ok("Usuário cadastrado!");

        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginUsuarioDto dto)
        {
            var token = await _usuarioService.Login(dto);
            return Ok(token);
        }

        [HttpGet("Consultar")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Consultar()
        {
            var usuariosFormatados = await _usuarioService.Consultar();
            return Ok(usuariosFormatados);
        }

        [HttpGet("ConsultarPorId/{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> ConsultarPorId(string id)
        {
            var usuarioFormatado = await _usuarioService.ConsultarPorId(id);
            return Ok(usuarioFormatado);
        }

        [HttpPost("VerificarEmail")]
        public async Task<IActionResult> VerificarEmail(string token)
        {
            await _usuarioService.VerificarEmail(token);
            return Ok("Usuario Verificado");
        }

        [HttpPost("EsqueciMinhaSenha")]
        public async Task<IActionResult> EsqueciMinhaSenha(string email)
        {
            await _usuarioService.EsqueciMinhaSenha(email);
            return Ok("Agora voce pode resetar sua senha");
        }

        [HttpPost("ResetarSenha")]
        public async Task<IActionResult> ResetarSenha(ResetPasswordDto dto)
        {
            await _usuarioService.ResetarSenha(dto);
            return Ok("Senha resetada com sucesso!");
        }

        [HttpPost("AlterarRole")]
        [Authorize(Roles = "admin")]
        
        public async Task<IActionResult> AlterarRoleUsuario(ChangeUserRoleDto dto)
        {
            await _usuarioService.AlterarRoleUsuario(dto);
            return Ok("Role alterada com sucesso!");
        }
    }
}

