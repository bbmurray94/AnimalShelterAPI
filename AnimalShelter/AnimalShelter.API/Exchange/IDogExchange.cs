using AnimalShelter.API.Models;
using AnimalShelter.Domain.Entities;

namespace AnimalShelter.API.Exchange
{
    public interface IDogsExchange
    {
        DogModel? Pack(Dog? dog);
        IEnumerable<DogModel?> Pack(IEnumerable<Dog?> dogList);
    }
}
