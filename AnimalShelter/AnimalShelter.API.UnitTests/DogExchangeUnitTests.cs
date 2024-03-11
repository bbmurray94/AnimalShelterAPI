using AnimalShelter.API.Exchange;
using AnimalShelter.API.Models;
using AnimalShelter.Domain.Entities;
using AnimalShelter.Domain.Enums;
using NUnit.Framework;
using System.Diagnostics;
using System.Reflection;

namespace AnimalShelter.API.UnitTests
{
    internal class DogExchangeUnitTests
    {
        private readonly int AValidId = 1;
        private readonly int AValidId2 = 2;
        private readonly string? AValidName = "Bubby";
        private readonly string? AValidName2 = "Hero";
        private readonly string? AValidDescription = "Brown and white";
        private readonly string? AValidDescription2 = "White and black";
        private readonly int AValidAge = 5;
        private readonly int AValidAge2 = 2;
        private readonly bool AValidHumaneInvestigation = false;
        private readonly bool AValidHumaneInvestigation2 = false;
        private readonly Sex AValidSex = Sex.Male;
        private readonly Sex AValidSex2 = Sex.Female;
        private readonly Level AValidLevel = Level.Green;
        private readonly Level AValidLevel2 = Level.Yellow;
        private readonly string? AValidLocation = "Dog Hold A";
        private readonly string? AValidLocation2 = "Dog Hold B";
        private readonly string? AValidKennelNumber = "13";
        private readonly string? AValidKennelNumber2 = "12";
        private readonly bool AValidIsHouseBroken = true;
        private readonly bool AValidIsHouseBroken2 = true;
        private readonly string? AValidBreed = "Pit Bull mix";
        private readonly string? AValidBreed2 = "Terror mix";

        private readonly int AValidNoteId = 1;
        private readonly int AValidNoteId2 = 2;
        private readonly string? AValidNote = "Needs harness";
        private readonly string? AValidNote2 = "Bring treats";

        [Test]
        public void DogsExchange__Dog_Pack_ValidObject_ReturnsAValidModel() 
        {
            Dog dog = new Dog
            {
                Id = AValidId,
                Name = AValidName,
                Description = AValidDescription,
                Age = AValidAge,
                UnderHumaneInvestigation = AValidHumaneInvestigation,
                Sex = AValidSex,
                Level = AValidLevel,
                Location = AValidLocation,
                KennelNumber = AValidKennelNumber,
                IsHouseBroken = AValidIsHouseBroken,
                Breed = AValidBreed,              
            };

            DogsExchange dogExchange = new DogsExchange();
            DogModel? model = dogExchange.Pack(dog);

            Assert.IsNotNull(model);
            Assert.That(model?.Id, Is.EqualTo(AValidId));
            Assert.That(model?.Name, Is.EqualTo(AValidName));
            Assert.That(model?.Description, Is.EqualTo(AValidDescription));
            Assert.That(model?.Age, Is.EqualTo(AValidAge));
            Assert.That(model?.UnderHumaneInvestigation, Is.EqualTo(AValidHumaneInvestigation));
            Assert.That(model?.Sex, Is.EqualTo(AValidSex.ToString()));
            Assert.That(model?.Level, Is.EqualTo(AValidLevel.ToString()));
            Assert.That(model?.Location, Is.EqualTo(AValidLocation));
            Assert.That(model?.KennelNumber, Is.EqualTo(AValidKennelNumber));
            Assert.That(model?.IsHouseBroken, Is.EqualTo(AValidIsHouseBroken));
            Assert.That(model?.Breed, Is.EqualTo(AValidBreed));
        }

        [Test]
        public void DogsExchange__Dog_Pack_EmptyObject_ReturnsEmptyObject() 
        {
            Dog dog = new Dog();

            DogsExchange dogExchange = new DogsExchange();
            DogModel? model = dogExchange.Pack(dog);

            Assert.IsNotNull(model);
            Assert.That(model?.Id, Is.EqualTo(0));
            Assert.That(model?.Name, Is.Null);
            Assert.That(model?.Description, Is.Null);
            Assert.That(model?.Age, Is.EqualTo(0));
            Assert.That(model?.UnderHumaneInvestigation, Is.False);
            Assert.That(model?.Sex, Is.EqualTo(Sex.Unknown.ToString()));
            Assert.That(model?.Level, Is.EqualTo(Level.Blue.ToString()));
            Assert.That(model?.Location, Is.Null);
            Assert.That(model?.KennelNumber, Is.Null);
            Assert.That(model?.IsHouseBroken, Is.False);
            Assert.That(model?.Breed, Is.Null);
        }

        [Test]
        public void DogsExchange__Dog_Pack_NullObject_ReturnsNullObject()
        {
            Dog? dog = null;

            DogsExchange dogExchange = new DogsExchange();
            DogModel? model = dogExchange.Pack(dog);

            Assert.IsNull(model);
        }

        [Test]
        public void DogsExchange__DogList_Pack_ValidList_ReturnsAValidModelList() 
        {
            List<Dog> dogList = new List<Dog>()
            {
                new Dog
                {
                    Id = AValidId,
                    Name = AValidName,
                    Description = AValidDescription,
                    Age = AValidAge,
                    UnderHumaneInvestigation = AValidHumaneInvestigation,
                    Sex = AValidSex,
                    Level = AValidLevel,
                    Location = AValidLocation,
                    KennelNumber = AValidKennelNumber,
                    IsHouseBroken = AValidIsHouseBroken,
                    Breed = AValidBreed,
                },
                new Dog
                {
                    Id = AValidId2,
                    Name = AValidName2,
                    Description = AValidDescription2,
                    Age = AValidAge2,
                    UnderHumaneInvestigation = AValidHumaneInvestigation2,
                    Sex = AValidSex2,
                    Level = AValidLevel2,
                    Location = AValidLocation2,
                    KennelNumber = AValidKennelNumber2,
                    IsHouseBroken = AValidIsHouseBroken2,
                    Breed = AValidBreed2,
                }
            };
            
            DogsExchange dogsExchange = new DogsExchange();
            List<DogModel?> modelList = dogsExchange.Pack(dogList).ToList();

            Assert.That(modelList, Is.Not.Empty);
            Assert.That(modelList[0]?.Id, Is.EqualTo(AValidId));
            Assert.That(modelList[0]?.Name, Is.EqualTo(AValidName));
            Assert.That(modelList[1]?.Id, Is.EqualTo(AValidId2));
            Assert.That(modelList[1]?.Name, Is.EqualTo(AValidName2));
        }

        [Test]
        public void DogsExchange__DogList_Pack_EmptyList_ReturnsNullObjectList() 
        {
            List<Dog> dogList = new List<Dog>();

            DogsExchange dogsExchange = new DogsExchange();
            List<DogModel?> modelList = dogsExchange.Pack(dogList).ToList();

            Assert.That(modelList, Is.Empty);
        }

        [Test]
        public void DogsExchange__DogNote_Pack_ValidObject_ReturnsAValidModel() 
        {
            DogNote dogNote = new DogNote 
            {
                Id = AValidNoteId,
                DogId = AValidId,
                Note = AValidNote,
            };

            DogsExchange dogsExchange = new DogsExchange();
            DogNoteModel model = dogsExchange.Pack(dogNote);

            Assert.NotNull(model);
            Assert.That(model.Id, Is.EqualTo(AValidNoteId));
            Assert.That(model.DogId, Is.EqualTo(AValidId));
            Assert.That(model.Note, Is.EqualTo(AValidNote));
        }

        [Test]
        public void DogsExchange__DogNote_Pack_EmptyObject_ReturnsNullObject() 
        {

            DogNote dogNote = new DogNote();

            DogsExchange dogExchange = new DogsExchange();
            DogNoteModel? model = dogExchange.Pack(dogNote);

            Assert.IsNotNull(model);
            Assert.That(model?.Id, Is.EqualTo(0));
            Assert.That(model?.DogId, Is.EqualTo(0));
            Assert.That(model?.Note, Is.Null);
        }

        [Test]
        public void DogsExchange__DogNote_Pack_NullObject_ReturnsNullObject()
        {
            DogNote? dogNote = null;

            DogsExchange dogExchange = new DogsExchange();
            DogNoteModel? model = dogExchange.Pack(dogNote);

            Assert.IsNull(model);
        }

        [Test]
        public void DogsExchange__DogNoteList_Pack_ValidList_ReturnsAValidModelList() 
        {
            List<DogNote> dogNoteList = new List<DogNote>()
            {
                new DogNote
                {
                    Id = AValidNoteId,
                    DogId = AValidId,
                    Note = AValidNote,
                },
                new DogNote
                {
                    Id = AValidNoteId2,
                    DogId = AValidId2,
                    Note = AValidNote2,
                }
            };

            DogsExchange dogsExchange = new DogsExchange();
            List<DogNoteModel?> modelList = dogsExchange.Pack(dogNoteList).ToList();

            Assert.That(modelList, Is.Not.Empty);
            Assert.That(modelList[0]?.Id, Is.EqualTo(AValidNoteId));
            Assert.That(modelList[0]?.DogId, Is.EqualTo(AValidId));
            Assert.That(modelList[0]?.Note, Is.EqualTo(AValidNote));
            Assert.That(modelList[1]?.Id, Is.EqualTo(AValidNoteId2));
            Assert.That(modelList[1]?.DogId, Is.EqualTo(AValidId2));
            Assert.That(modelList[1]?.Note, Is.EqualTo(AValidNote2));
        }

        [Test]
        public void DogsExchange__DogNoteList_Pack_EmptyList_ReturnsNullObjectList()
        {
            List<DogNote> dogNoteList = new List<DogNote>();

            DogsExchange dogsExchange = new DogsExchange();
            List<DogNoteModel?> modelList = dogsExchange.Pack(dogNoteList).ToList();

            Assert.That(modelList, Is.Empty);
        }

        [Test]
        public void DogsExchange__DogNote_Unpack_ValidModel_ReturnsAValidObject() 
        {
            DogNoteModel model = new DogNoteModel 
            {
                Id = AValidNoteId,
                DogId = AValidId,
                Note = AValidNote,
            };

            DogsExchange dogsExchange = new DogsExchange();
            DogNote dogNote = dogsExchange.Unpack(model);

            Assert.NotNull(dogNote);
            Assert.That(dogNote.Id, Is.EqualTo(AValidNoteId));
            Assert.That(dogNote.DogId, Is.EqualTo(AValidId));
            Assert.That(dogNote.Note, Is.EqualTo(AValidNote));
        }

        [Test]
        public void DogsExchange__Dog_Unpack_EmptyObject_ReturnsEmptyObject() 
        {
            DogNoteModel model = new DogNoteModel();

            DogsExchange dogsExchange = new DogsExchange();
            DogNote dogNote = dogsExchange.Unpack(model);

            Assert.NotNull(dogNote);
            Assert.That(dogNote?.Id, Is.EqualTo(0));
            Assert.That(dogNote?.DogId, Is.EqualTo(0));
            Assert.That(dogNote?.Note, Is.Null);
        }

        [Test]
        public void DogsExchange__DogNote_Unpack_NullObject_ReturnsNullObject()
        {
            DogNoteModel? model = null;

            DogsExchange dogExchange = new DogsExchange();
            DogNote? dogNote = dogExchange.Unpack(model);

            Assert.IsNull(model);
        }
    }
}
