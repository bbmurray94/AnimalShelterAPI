using AnimalShelter.API.Models;
using AnimalShelter.Domain.Entities;

namespace AnimalShelter.API.Exchange
{
    public interface IDogsExchange
    {
        DogModel Pack(Dog? dog);
        IEnumerable<DogModel?> Pack(IEnumerable<Dog?> dogList);

        Dog Unpack(DogModel? dogModel);

        DogNoteModel Pack(DogNote? dogNote);
        IEnumerable<DogNoteModel?> Pack(IEnumerable<DogNote?> dogNoteList);
        DogNote Unpack(DogNoteModel? dogNoteModel);
    }
}
