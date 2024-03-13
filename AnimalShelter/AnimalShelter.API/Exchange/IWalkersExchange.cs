using AnimalShelter.API.Models;
using AnimalShelter.Domain.Entities;

namespace AnimalShelter.API.Exchange
{
    public interface IWalkersExchange
    {
        WalkerModel? Pack(Walker? walker);
        IEnumerable<WalkerModel?> Pack(IEnumerable<Walker?> walkerList);
        Walker? Unpack(WalkerModel? walkerModel);
    }
}
