using MailKit.Net.Smtp;
using MailKit.Security;

namespace EmailApp_Mailkit.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmailController : ControllerBase
{
    [HttpPost("send-mail")]
    public IActionResult SendEmail(string body)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse("may53@ethereal.email"));
        email.To.Add(MailboxAddress.Parse("may53@ethereal.email"));
        email.Subject = "Test E-mail to Big Boss :)";
        email.Body = new TextPart(TextFormat.Text) { Text = body };

        using var smtp = new SmtpClient();
        //Burada smtp.gmail.com - smtp.live.com - smtp.hotmail.com - smtp.office365.com kullanılabilir.
        smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
        //email ve password
        smtp.Authenticate("may53@ethereal.email", "chpQZjh5GEb2kwwccD");
        smtp.Send(email);
        smtp.Disconnect(true);
        
        return Ok();
    }
}
