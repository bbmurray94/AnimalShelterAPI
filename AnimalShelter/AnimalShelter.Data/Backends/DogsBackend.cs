using AnimalShelter.Data.Data;
using AnimalShelter.Data.Interfaces;
using AnimalShelter.Domain.Entities;
using AnimalShelter.Domain.Enums;

namespace AnimalShelter.Data.Backends
{
    public class DogsBackend : IDogsBackend
    {
        private readonly AnimalShelterContext _context;

        public DogsBackend(AnimalShelterContext context) 
        {
            _context = context;
        }
        
        public async Task<Dog> GetDog(int id)
        {
            return new Dog
            {
                Id = id,
                Name = "Bubby",
                Description = "Needs harness",
                Age = 5,
                UnderHumaneInvestigation = false,
                Sex = Sex.Male,
                Level = Level.Green,
                Location = "Dog Hold A",
                KennelNumber = "13",
                IsHouseBroken = true,
                Breed = "Pit Bull mix",
            };
        }

        public async Task<IEnumerable<Dog>> GetDogList()
        {
            List<Dog> dogs = new List<Dog> 
            {
                new Dog
                {
                    Id = 1,
                    Name = "Bubby",
                    Description = "Needs harness",
                    Age = 5,
                    UnderHumaneInvestigation = false,
                    Sex = Sex.Male,
                    Level = Level.Green,
                    Location = "Dog Hold A",
                    KennelNumber = "13",
                    IsHouseBroken = true,
                    Breed = "Pit Bull mix",
                },
                new Dog
                {
                    Id = 2,
                    Name = "Tico",
                    Description = "Needs harness",
                    Age = 5,
                    UnderHumaneInvestigation = false,
                    Sex = Sex.Male,
                    Level = Level.Green,
                    Location = "Dog Hold A",
                    KennelNumber = "14",
                    IsHouseBroken = true,
                    Breed = "Pit Bull mix",
                }
            };

            return dogs;
        }
    }
}
