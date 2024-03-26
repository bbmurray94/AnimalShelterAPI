using AnimalShelter.API.Models;
using AnimalShelter.Domain.Entities;

namespace AnimalShelter.API.Exchange
{
    public interface IActivitiesExchange
    {
        DogActivityModel? Pack(DogActivity? dogActivity);
        IEnumerable<DogActivityModel?> Pack(IEnumerable<DogActivity?> dogActivityList);
        DogActivity Unpack(DogActivityCreationModel? dogActivityCreationModel);
    }
}
