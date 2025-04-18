using CarBookingAPI.DataSeeds;
using CarBookingAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace CarBookingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {

        [HttpGet("all")]
        public IEnumerable<Car> Get() => Seed.Cars;

        [HttpGet("{id}")]
        public Car GetById(int id) => Seed.Cars.SingleOrDefault(p => p.Id == id);

        [HttpGet("filter")]
        public ActionResult<List<Car>> Get(FilterModel filter) {

            // return Seed.Cars.Where(x => String.Equals(x.Name, filter.Name)).Select(x => x);
            var listsCars = Seed.Cars;
            var resultList = new List<Car>();
            for (int i = 0; i < listsCars.Count; i++)
            {
                var car = listsCars[i];
                if (filter.Name == car.Name)
                {
                    resultList.Add(car);
                }
                continue;
            }
            if (resultList.Count == 0) return Ok("Нет таких машин");
            return Ok(resultList);
        }
    }
}
