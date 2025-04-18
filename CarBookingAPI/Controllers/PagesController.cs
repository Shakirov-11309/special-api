using Microsoft.AspNetCore.Mvc;

namespace CarBookingAPI.Controllers
{
    [ApiController]
    [Route("[conroller]")]
    public class PagesController : Controller
    {
        [HttpGet("/sendEmail")]
        public IActionResult GetFormSendEmail() => View("FromEmailSend");
    }
}
