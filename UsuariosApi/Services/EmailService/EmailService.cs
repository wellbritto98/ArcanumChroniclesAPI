using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using UsuariosApi.Data.Dtos.EmailDto;

namespace UsuariosApi.Services.EmailService;

public class EmailService
{
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public void EnviarEmail(EmailDto dto)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(_configuration.GetSection("EmailUserName").Value));
        email.To.Add(MailboxAddress.Parse(dto.To));
        email.Subject = dto.Subject;
        email.Body = new TextPart(TextFormat.Plain) {Text = dto.Body};
        using var smtp = new SmtpClient();
        smtp.Connect(_configuration.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
        smtp.Authenticate(_configuration.GetSection("EmailUserName").Value, _configuration.GetSection("EmailPassword").Value );
        smtp.Send(email);
        smtp.Disconnect(true);
    }
}