using AnimalShelter.API.Models;
using AnimalShelter.Domain.Entities;
using AnimalShelter.Domain.Enums;
using System.Diagnostics;

namespace AnimalShelter.API.Exchange
{
    public class DogsExchange : IDogsExchange
    {
        public DogModel Pack(Dog? dog)
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
                Age = dog.Age,
                Sex = dog.Sex.ToString(),
                UnderHumaneInvestigation = dog.UnderHumaneInvestigation,
                Breed = dog.Breed,
                Level = dog.Level.ToString(),
                Location = dog.Location,
                KennelNumber= dog.KennelNumber,
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

        public DogNoteModel Pack(DogNote? dogNote)
        {
            if (dogNote == null) 
            {
                return null;
            }
            return new DogNoteModel 
            {
                Id = dogNote.Id,
                DogId = dogNote.DogId,
                Note = dogNote.Note,
            };
        }

        public IEnumerable<DogNoteModel?> Pack(IEnumerable<DogNote?> dogNoteList)
        {
            List<DogNoteModel?> modelList = new List<DogNoteModel?>();
            if (dogNoteList == null)
            {
                return modelList;
            }

            foreach (DogNote? dogNote in dogNoteList)
            {
                modelList.Add(Pack(dogNote));
            }

            return modelList;
        }

        public Dog Unpack(DogModel dogModel) 
        {
            return new Dog
            {
                Id = dogModel.Id,
                Name = dogModel.Name,
                Description = dogModel.Description,
                Age = dogModel.Age,
                Sex = (Sex)Enum.Parse(typeof(Sex), dogModel.Sex),
                UnderHumaneInvestigation = dogModel.UnderHumaneInvestigation,
                Breed = dogModel.Breed,
                Level = (Level)Enum.Parse(typeof(Level), dogModel.Level),
                Location = dogModel.Location,
                KennelNumber = dogModel.KennelNumber,
                IsHouseBroken = dogModel.IsHouseBroken,
            };
        }

        public DogNote? Unpack(DogNoteModel? dogNoteModel)
        {
            if (dogNoteModel == null) 
            {
                return null;
            }
            return new DogNote
            {
                Id = dogNoteModel.Id,
                DogId = dogNoteModel.DogId,
                Note = dogNoteModel.Note,
            };
        }
    }
}
