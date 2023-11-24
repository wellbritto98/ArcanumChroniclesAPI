using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Dtos.RegionDto;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class RegionController : ControllerBase
{
    
    private RegionService _regionService;

    public RegionController(RegionService regionService)
    {
        _regionService = regionService;
    }
    
    [HttpPost("CriarPolo")]
    public async Task<IActionResult> CreatePolo(CreatePoloDto dto)
    {
        var resultado = await _regionService.CreatePolo(dto);
        if (resultado.Success)
        {
            return Ok(resultado.Message);
        }
        else
        {
            return BadRequest(resultado.Message);
        }
    }
    
    [HttpGet("Polos")]
    public async Task<IActionResult> GetPolos()
    {
        return Ok(await _regionService.GetPolos());
    }
}