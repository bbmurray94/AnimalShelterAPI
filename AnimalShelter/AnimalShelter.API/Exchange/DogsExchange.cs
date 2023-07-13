using AnimalShelter.API.Models;
using AnimalShelter.Domain.Entities;

namespace AnimalShelter.API.Exchange
{
    public class DogsExchange : IDogsExchange
    {
        public DogModel? Pack(Dog? dog)
        {
            if (dog == null) 
            {
                return null;
            }
            return new DogModel 
            { 
                Id = dog.Id,
                Name = dog.Name,
                Description = dog.Description,
                Age= dog.Age,
                Sex = dog.Sex,
                HumaneInvestigation = dog.HumaneInvestigation,
                Breed = dog.Breed,
                Level = dog.Level,
                Location = dog.Location,
                IsHouseBroken = dog.IsHouseBroken,
            };
        }

        public IEnumerable<DogModel?> Pack(IEnumerable<Dog> dogList)
        {
            List<DogModel?> modelList = new List<DogModel?>();
            if (dogList == null) 
            {
                return modelList;
            }

            foreach (Dog? dog in dogList) 
            {
                modelList.Add(Pack(dog));
            }

            return modelList;
        }
    }
}
