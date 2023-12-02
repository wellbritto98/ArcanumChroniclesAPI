using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Data.Dtos.UsuarioDtos;
using UsuariosApi.Services.Usuario;

namespace UsuariosApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UsuarioController : ControllerBase
    {
        private UsuarioService _usuarioService;

        public UsuarioController(UsuarioService cadastroService)
        {
            _usuarioService = cadastroService;
        }

        [HttpPost("cadastro")]
        public async Task<IActionResult> CadastraUsuario(CreateUsuarioDto dto)
        {
            var response = await _usuarioService.CadastraUsuario(dto);
            if (response.Success)
            {
                return Ok(response.Message);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }


        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginUsuarioDto dto)
        {
            var response = await _usuarioService.Login(dto);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
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

        /* [HttpPost("VerificarEmail")]
         public async Task<IActionResult> VerificarEmail(string token)
         {
             var response = await _usuarioService.VerificarEmail(token);
             if (response.Success)
             {
                 return Ok(response.Message);
             }
             else
             {
                 return BadRequest(response.Message);
             }
         }*/
        [HttpGet("VerificarEmail")]
        public async Task<IActionResult> VerificarEmail(string token)
        {
            var response = await _usuarioService.VerificarEmail(token);
            if (response.Success)
            {
                return Ok(response.Message);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }


        [HttpPost("EsqueciMinhaSenha")]
        public async Task<IActionResult> EsqueciMinhaSenha(string email)
        {
            var response = await _usuarioService.EsqueciMinhaSenha(email);
            if (response.Success)
            {
                return Ok(response.Message);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpPost("ResetarSenha")]
        public async Task<IActionResult> ResetarSenha(ResetPasswordDto dto)
        {
            var response = await _usuarioService.ResetarSenha(dto);
            if (response.Success)
            {
                return Ok(response.Message);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpPost("AlterarRole")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AlterarRoleUsuario(ChangeUserRoleDto dto)
        {
            await _usuarioService.AlterarRoleUsuario(dto);
            return Ok("Role alterada com sucesso!");
        }

        [HttpPost("VerificaJWT")]
        public async Task<IActionResult> VerificaJWT(string token)
        {
            var response = await _usuarioService.VerificaJWTUsuario(token);
            if (response.Success)
            {
                return Ok(response.Message);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpPost("ReenviarEmailVerificacao")]
        public async Task<IActionResult> ReenviarEmailVerificacao(string email)
        {
            var response = await _usuarioService.EnviaEmailVerificacao(email);
            if (response.Success)
            {
                return Ok(response.Message);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }
    }
}