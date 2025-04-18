using CarBookingAPI.Enums;
using CarBookingAPI.Models;

namespace CarBookingAPI.DataSeeds
{
    public static class Seed
    {
        public static List<Car> Cars = new List<Car>(){
            new Car(){
                Id = 1,
                Name = "Лагодюк",
                Description = "Вот это машина!",
                Price = 345,
                Transmissions = TransmissionType.Manual,
                Type = CarType.Sport
            }

        };

        public static List<WorkExperience> WorkExperiences = new List<WorkExperience>(){
            new WorkExperience(){
               Year = "2021 - 2022",
               Name = "Google Inc.",
               logoUrl = "assets/img/google.svg",
               Role = "Senior Product Designer"
            },
            new WorkExperience(){
               Year = "2022 - 2023",
               Name = "Meta Inc.",
               logoUrl = "assets/img/meta.svg",
               Role = "Product Designer"
            }

        };
        
    }
}