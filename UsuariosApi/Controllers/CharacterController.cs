using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Dtos.UsuarioDtos;
using UsuariosApi.Services.CharacterService;

namespace UsuariosApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CharacterController : ControllerBase
    {
        private CharacterService _characterServices;

        public CharacterController(CharacterService characterServices)
        {
            _characterServices=characterServices;
        }

        [HttpPost ("CriarChar")]
        [Authorize (Roles = "player, admin")]
        public async Task<IActionResult> CreateCharacter(CreateCharacterDto dto)
        {
            var resultado = await _characterServices.CriaPersonagem(dto);
            if (resultado.Sucesso)
            {
                return Ok(resultado.Mensagem);
            }
            else
            {
                return BadRequest(resultado.Mensagem);
            }
        }

    }
}
