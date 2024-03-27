using AnimalShelter.API.Models;
using AnimalShelter.Domain.Entities;
using AnimalShelter.Domain.Enums;

namespace AnimalShelter.API.Exchange
{
    public class ActivitiesExchange : IActivitiesExchange
    {
        private IWalkersExchange _walkersExchange;
        private IDogsExchange _dogsExchange;
        public ActivitiesExchange(IWalkersExchange walkersExchange,
                                    IDogsExchange dogsExchange) 
        {
            _walkersExchange = walkersExchange;
            _dogsExchange = dogsExchange;
        }

        public DogActivityModel? Pack(DogActivity? dogActivity)
        {
            if (dogActivity == null) 
            {
                return null;
            }

            return new DogActivityModel 
            {
                Id = dogActivity.Id,
                Dog = _dogsExchange.Pack(dogActivity.Dog),
                Walker = _walkersExchange.Pack(dogActivity.Walker),
                Date = dogActivity.Date.ToString("yyyy-MM-dd"),
                Timeslot = dogActivity.Timeslot.ToString(),
                Type = dogActivity.Type.ToString(),
            };
        }

        public IEnumerable<DogActivityModel?> Pack(IEnumerable<DogActivity?> dogActivityList)
        {
            List<DogActivityModel?> modelList = new List<DogActivityModel?>();
            if (dogActivityList == null)
            {
                return modelList;
            }

            foreach (DogActivity? dogActivity in dogActivityList)
            {
                modelList.Add(Pack(dogActivity));
            }

            return modelList;
        }

        public DogActivity? Unpack(DogActivityCreationModel? dogActivityCreationModel)
        {
            if (dogActivityCreationModel == null) 
            {
                return null;
            }

            return new DogActivity
            {
                Id = dogActivityCreationModel.Id,
                Type = dogActivityCreationModel?.Type != null ? (DogActivityType)Enum.Parse(typeof(DogActivityType), dogActivityCreationModel.Type) : DogActivityType.Short_Walk,
                Timeslot = dogActivityCreationModel?.Timeslot != null ? (Timeslot)Enum.Parse(typeof(Timeslot), dogActivityCreationModel.Timeslot) : Timeslot.Morning,
                Date = dogActivityCreationModel?.Date != null ? DateTime.Parse(dogActivityCreationModel.Date) : DateTime.MinValue,
                DogId = dogActivityCreationModel.DogId,
                WalkerId = dogActivityCreationModel?.WalkerId,
            };
        }
    }
}
