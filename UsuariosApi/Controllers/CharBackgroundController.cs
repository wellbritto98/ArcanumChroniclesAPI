using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Dtos.BackgroundDto;
using UsuariosApi.Models;
using UsuariosApi.Services.BackgroundService;

namespace UsuariosApi.Controllers;



[ApiController]
[Route("api/[controller]")]
public class CharBackgroundController : ControllerBase
{
    private CharBackgroundService _charBackgroundService;

    public CharBackgroundController(CharBackgroundService charBackgroundService)
    {
        _charBackgroundService = charBackgroundService;
    }
    
    [HttpPost("CriarChildhoodBackground")]
    public async Task<IActionResult> CreateChildhoodBackground(CreateChildhoodBackgroundDto dto)
    {
        var resultado = await _charBackgroundService.CreateChildhoodBackground(dto);
        if (resultado.Success)
        {
            return Ok(resultado.Message);
        }
        else
        {
            return BadRequest(resultado.Message);
        }
    }
    
    [HttpPost("CriarFatherBackground")]
    public async Task<IActionResult> CreateFatherBackground(CreateFatherBackgroundDto dto)
    {
        var resultado = await _charBackgroundService.CreateFatherBackground(dto);
        if (resultado.Success)
        {
            return Ok(resultado.Message);
        }
        else
        {
            return BadRequest(resultado.Message);
        }
    }
    
    [HttpPost("CriarMotherBackground")]
    public async Task<IActionResult> CreateMotherBackground(CreateMotherBackgroundDto dto)
    {
        var resultado = await _charBackgroundService.CreateMotherBackground(dto);
        if (resultado.Success)
        {
            return Ok(resultado.Message);
        }
        else
        {
            return BadRequest(resultado.Message);
        }
    }
    
    [HttpGet("ChildhoodBackgrounds")]
    public async Task<IActionResult> GetChildhoodBackgrounds()
    {
        return Ok(await _charBackgroundService.GetChildhoodBackgrounds());
    }
    
    [HttpGet("FatherBackgrounds")]
    public async Task<IActionResult> GetFatherBackgrounds()
    {
        return Ok(await _charBackgroundService.GetFatherBackgrounds());
    }
    
    [HttpGet("MotherBackgrounds")]
    public async Task<IActionResult> GetMotherBackgrounds()
    {
        return Ok(await _charBackgroundService.GetMotherBackgrounds());
    }
    
    [HttpDelete("DeleteChildhoodBackground/{id}")]
    public async Task<IActionResult> DeleteChildhoodBackground(int id)
    {
        await _charBackgroundService.DeleteChildhoodBackground(id);
        return Ok();
    }
    
    [HttpDelete("DeleteFatherBackground/{id}")]
    
    public async Task<IActionResult> DeleteFatherBackground(int id)
    {
        await _charBackgroundService.DeleteFatherBackground(id);
        return Ok();
    }
    
    [HttpDelete("DeleteMotherBackground/{id}")]
    
    public async Task<IActionResult> DeleteMotherBackground(int id)
    {
        await _charBackgroundService.DeleteMotherBackground(id);
        return Ok();
    }
    
    
    
}