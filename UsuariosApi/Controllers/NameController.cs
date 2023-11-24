using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Dtos.CharacterDto;
using UsuariosApi.Services.CharacterService;

namespace UsuariosApi.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class NameController : ControllerBase
{
    private NameService _nameService;

    public NameController(NameService nameService)
    {
        _nameService = nameService;
    }

    [HttpPost("CriarNome")]
    public async Task<IActionResult> CreateName(CreateNameDto dto)
    {
        var resultado = await _nameService.CreateName(dto);
        if (resultado.Success)
        {
            return Ok(resultado.Message);
        }
        else
        {
            return BadRequest(resultado.Message);
        }
    }
    
    [HttpPost("CriarSobrenome")]
    public async Task<IActionResult> CreateSurname(CreateSurnameDto dto)
    {
        var resultado = await _nameService.CreateSurname(dto);
        if (resultado.Success)
        {
            return Ok(resultado.Message);
        }
        else
        {
            return BadRequest(resultado.Message);
        }
    }
    
    [HttpGet("Sobrenomes")]
    public async Task<IActionResult> GetSurnames()
    {
        return Ok(await _nameService.GetSurnames());
    }
    
    [HttpGet("NomesFem")]
    public async Task<IActionResult> GetFemNames()
    {
        return Ok(await _nameService.GetFemNames());
    }
    
    [HttpGet("NomesMasc")]
    public async Task<IActionResult> GetMaleNames()
    {
        return Ok(await _nameService.GetMaleNames());
    }
    
    [HttpDelete("DeletarNome")]
    public async Task<IActionResult> DeleteName(string nameChar)
    {
        await _nameService.DeleteName(nameChar);
        return Ok();
    }
}