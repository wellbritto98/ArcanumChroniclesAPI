using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Dtos.UsuarioDtos;
using UsuariosApi.Models;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class UsuarioController : ControllerBase
{
    private UsuarioService _usuarioService;

    public UsuarioController(UsuarioService cadastroService)
    {
        _usuarioService=cadastroService;
    }

    [HttpPost("cadastro")]
    public async Task<IActionResult> CadastraUsuario(CreateUsuarioDto createUsuarioDto)
    {
        IdentityResult resultado = await _usuarioService.Cadastra(createUsuarioDto);
        if (resultado.Succeeded)
        {
            return Ok("Usuário cadastrado com sucesso !");
        }
        else
        {
            return BadRequest(resultado.Errors.Select(e => e.Description));
        }
    }


    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(LoginUsuarioDto dto)
    {
        string resultMessage = await _usuarioService.Login(dto);
        if (resultMessage == "Usuário autenticado!")
        {
            return Ok(resultMessage);
        }
        else
        {
            return BadRequest(resultMessage);
        }
    }


}
