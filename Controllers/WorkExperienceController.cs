using CarBookingAPI.DataSeeds;
using CarBookingAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarBookingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkExperienceController : ControllerBase
    {


        [HttpGet]
        public IEnumerable<WorkExperience> GetAll() => Seed.WorkExperiences;
    }
}
