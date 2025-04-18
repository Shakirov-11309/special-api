using CarBookingAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace CarBookingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailSenderController : ControllerBase
    {

        // сверстать страницу с формой
        // написать метод отправки данных с формы на этот метод

        [HttpPost]
        public IActionResult SendEmail([FromBody]FormModel formData)
        {
            // ДЗ
            // Вставить логику отправки письма на почту

            // отправляться два письма
            // 1 - отправляется на почту FormModel.EmailTo с текстом Ваша заявка принята
            // 2 - отправляется на почту вам с данными которые заданы на форме

            return Ok();
        }
    }
}
