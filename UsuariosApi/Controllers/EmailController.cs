using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit.Text;
using UsuariosApi.Data.Dtos.EmailDto;
using UsuariosApi.Services.EmailService;

namespace UsuariosApi.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class EmailController : ControllerBase
{
    private readonly EmailService _emailService;

    public EmailController(EmailService emailService)
    {
        _emailService = emailService;
    }
    
    [HttpPost]
    public IActionResult EnviaEmail(EmailDto dto)
    {
        _emailService.EnviarEmail(dto);
        return Ok();
    }
}