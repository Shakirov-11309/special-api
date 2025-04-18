using CarBookingAPI.DataSeeds;
using CarBookingAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarBookingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {

        [HttpGet("all")]
        public IEnumerable<Car> Get() => Seed.Cars;

        [HttpGet("{id}")]
        public Car GetByLagodyk(int id) => Seed.Cars.SingleOrDefault(p => p.Id == id);

        [HttpGet("filter")]
        public IEnumerable<Car> Get(FilterModel filter) {

            // TODO: filter

            return Seed.Cars;


        } 

    }
}
