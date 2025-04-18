using CarBookingAPI.Enums;

namespace CarBookingAPI.Models
{
    public class Car
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public TransmissionType Transmissions { get; set; }

        public CarType Type { get; set; }
    }
}
