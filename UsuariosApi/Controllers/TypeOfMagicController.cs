using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Dtos.TypeOfMagicDto;
using UsuariosApi.Services.TypeOfMagicService;

namespace UsuariosApi.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class TypeOfMagicController : ControllerBase
{
    private TypeOfMagicService _typeOfMagicService;

    public TypeOfMagicController(TypeOfMagicService typeOfMagicService)
    {
        _typeOfMagicService = typeOfMagicService;
    }
    
    [HttpPost("CriarTipoDeMagia")]
    public async Task<IActionResult> CreateTypeOfMagic(CreateTypeOfMagicDto dto)
    {
        var resultado = await _typeOfMagicService.CreateTypeOfMagic(dto);
        if (resultado.Success)
        {
            return Ok(resultado.Message);
        }
        else
        {
            return BadRequest(resultado.Message);
        }
    }
    
    [HttpGet("TiposDeMagia")]
    public async Task<IActionResult> GetTypesOfMagic()
    {
        return Ok(await _typeOfMagicService.GetTypesOfMagic());
    }
    
    [HttpDelete("DeletarTipoDeMagia/{typeOfMagicName}")]
    public async Task<IActionResult> DeleteTypeOfMagic(string typeOfMagicName)
    {
        await _typeOfMagicService.DeleteTypeOfMagic(typeOfMagicName);
        return Ok();
    }
    
    [HttpPut("AtualizarTipoDeMagia")]
    public async Task<IActionResult> UpdateTypeOfMagic(UpdateTypeOfMagicDto dto)
    {
        var resultado = await _typeOfMagicService.UpdateTypeOfMagic(dto);
        if (resultado.Success)
        {
            return Ok(resultado.Message);
        }
        else
        {
            return BadRequest(resultado.Message);
        }
    }
    
    [HttpGet("TipoDeMagia/{id}")]
    public async Task<IActionResult> GetTypeOfMagic(int id)
    {
        return Ok(await _typeOfMagicService.GetTypeOfMagic(id));
    }
}