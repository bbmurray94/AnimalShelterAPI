using AnimalShelter.API.Models;
using AnimalShelter.Domain.Entities;

namespace AnimalShelter.API.Exchange
{
    public interface IActivitiesExchange
    {
        DogActivityModel? Pack(DogActivity? walk);
        IEnumerable<DogActivityModel?> Pack(IEnumerable<DogActivity?> walk);
    }
}
