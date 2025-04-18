using CarBookingAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Configuration;

namespace CarBookingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailSenderController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public EmailSenderController(IConfiguration configuration)
        {
            _configuration = configuration;
        }



        [HttpPost]
        public IActionResult SendEmail([FromBody] FormModel formData)
        {
            try
            {
                var smtpSettings = _configuration.GetSection("SmtpSettings");
                var fromEmail = smtpSettings["FromEmail"];
                var fromPassword = smtpSettings["FromPassword"];
                var smtpServer = smtpSettings["SmtpServer"];
                var smtpPort = int.Parse(smtpSettings["SmtpPort"]);
                var adminEmail = smtpSettings["AdminEmail"];

                // Отправка 1 письма
                SendEmail(
                    smtpServer, smtpPort, fromEmail, fromPassword,
                    formData.EmailTo,
                    "Ответ компании Caradver",
                    $"Здравствуйте, {formData.Name} ваша заявка принята");

                // Отправка 2 письма
                SendEmail(
                    smtpServer, smtpPort, fromEmail, fromPassword,
                    adminEmail,
                    $"Заявка пользователя {formData.Name}",
                    $"Имя: {formData.Name}\n" +
                    $"Сообщение: {formData.Message}\n" +
                    $"Время отправки: {formData.DateTime}\n" +
                    $"Почта пользователя: {formData.EmailTo}"
                );

                return Ok(new { message = "Письмо отправлен успешно" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Ошибка при отправки письма: {ex.Message}" });
            }
        }

        private void SendEmail(string smtpServer, int smtpPort, string fromEmail, string fromPassword,
                              string toEmail, string subject, string body)
        {
            using (var message = new MailMessage(fromEmail, toEmail))
            {
                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = false;

                using (var client = new SmtpClient(smtpServer, smtpPort))
                {
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential(fromEmail, fromPassword);
                    client.Send(message);
                }
            }
        }
    }
}
