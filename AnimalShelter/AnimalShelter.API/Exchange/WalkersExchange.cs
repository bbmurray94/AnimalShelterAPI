using AnimalShelter.API.Models;
using AnimalShelter.Domain.Entities;

namespace AnimalShelter.API.Exchange
{
    public class WalkersExchange : IWalkersExchange
    {
        public WalkerModel? Pack(Walker? walker)
        {
            if (walker == null) 
            {
                return null;
            }
            return new WalkerModel 
            {
                Id = walker.Id,
                FirstName = walker.FirstName,
                LastName = walker.LastName,
                Level = walker.Level.ToString(),
            };
        }

        public IEnumerable<WalkerModel?> Pack(IEnumerable<Walker?> walkerList)
        {
            List<WalkerModel?> modelList = new List<WalkerModel?>();
            if (walkerList == null)
            {
                return modelList;
            }

            foreach (Walker? walker in walkerList)
            {
                modelList.Add(Pack(walker));
            }

            return modelList;
        }
    }
}
