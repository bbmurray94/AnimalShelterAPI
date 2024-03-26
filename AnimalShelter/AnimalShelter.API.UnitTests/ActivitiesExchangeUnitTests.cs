using AnimalShelter.API.Exchange;
using AnimalShelter.API.Models;
using AnimalShelter.Domain.Entities;
using AnimalShelter.Domain.Enums;
using Moq;
using NUnit.Framework;


namespace AnimalShelter.API.UnitTests
{
    internal class ActivitiesExchangeUnitTests
    {
        private int AValidId = 1;
        private int AValidId2 = 2;
        private int AValidDogId = 3;
        private int AValidWalkerId = 4;
        private DateTime AValidDate = DateTime.Parse("2024/03/14");
        private string AValidDateString = "2024-03-14";
        private Timeslot AValidTimeslot = Timeslot.Afternoon;
        private Timeslot AValidTimeslot2 = Timeslot.Evening;
        private DogActivityType AValidDogActivityType = DogActivityType.Long_Walk;
        private DogActivityType AValidDogActivityType2 = DogActivityType.Play_Yard;
        private Walker AValidWalker = new Walker() 
        {
            Id = 1,
            FirstName = "John",
            LastName = "Smith",
            Level = Level.Green
        };
        private WalkerModel AValidWalkerModel = new WalkerModel 
        {
            Id = 1,
            FirstName = "John",
            LastName = "Smith",
            Level = "Green"
        };
        private Dog AValidDog = new Dog() 
        {
            Id = 1,
            Name = "Bubby",
            Age = 3,
            Description = "Brown and white",
            Sex = Sex.Male,
            Level = Level.Green,
            Location = "Dog Adoption",
            KennelNumber = "3",
            Breed = "Pit bull mix",
            IsHouseBroken = true,
            UnderHumaneInvestigation = true,
        };
        private DogModel AValidDogModel = new DogModel()
        {
            Id = 1,
            Name = "Bubby",
            Age = 3,
            Description = "Brown and white",
            Sex = "Male",
            Level = "Green",
            Location = "Dog Adoption",
            KennelNumber = "3",
            Breed = "Pit bull mix",
            IsHouseBroken = true,
            UnderHumaneInvestigation = true,
        };

        [Test]
        public void ActivitiesExchange__DogActivity_Pack_ValidObject_ReturnsAValidModel()
        {
            DogActivity activity = new DogActivity
            {
                Id = AValidId,
                Dog = AValidDog,
                Walker = AValidWalker,
                Date = AValidDate,
                Timeslot = AValidTimeslot,
                Type = AValidDogActivityType,
            };

            Mock<IWalkersExchange> walkersExchange = new Mock<IWalkersExchange>();
            walkersExchange.Setup(m => m.Pack(It.IsAny<Walker>())).Returns(AValidWalkerModel);
            Mock<IDogsExchange> dogsExchange = new Mock<IDogsExchange>();
            dogsExchange.Setup(m => m.Pack(It.IsAny<Dog>())).Returns(AValidDogModel);

            ActivitiesExchange activityExchange = new ActivitiesExchange(walkersExchange.Object, dogsExchange.Object);
            DogActivityModel? model = activityExchange.Pack(activity);

            Assert.IsNotNull(model);
            Assert.That(model?.Id, Is.EqualTo(AValidId));
            Assert.That(model?.Timeslot, Is.EqualTo(AValidTimeslot.ToString()));
            Assert.That(model?.Date, Is.EqualTo(AValidDateString));
            Assert.That(model?.Type, Is.EqualTo(AValidDogActivityType.ToString()));

            Assert.That(model?.Walker?.FirstName, Is.EqualTo(AValidWalkerModel.FirstName));
            Assert.That(model?.Walker?.LastName, Is.EqualTo(AValidWalkerModel.LastName));
            Assert.That(model?.Dog?.Id, Is.EqualTo(AValidDogModel.Id));
            Assert.That(model?.Dog?.Name, Is.EqualTo(AValidDogModel.Name));
        }

        [Test]
        public void ActivitiesExchange__DogActivity_Pack_EmptyObject_ReturnsEmptyObject() 
        {
            DogActivity dogActivity = new DogActivity();

            Mock<IWalkersExchange> walkersExchange = new Mock<IWalkersExchange>();
            walkersExchange.Setup(m => m.Pack(It.IsAny<Walker>())).Returns(new WalkerModel());
            Mock<IDogsExchange> dogsExchange = new Mock<IDogsExchange>();
            dogsExchange.Setup(m => m.Pack(It.IsAny<Dog>())).Returns(new DogModel());

            ActivitiesExchange activityExchange = new ActivitiesExchange(walkersExchange.Object, dogsExchange.Object);
            DogActivityModel? model = activityExchange.Pack(dogActivity);

            Assert.IsNotNull(model);

            Assert.That(model?.Id, Is.EqualTo(0));
            Assert.That(model?.Date, Is.EqualTo("0001-01-01"));
            Assert.That(model?.Timeslot, Is.EqualTo(Timeslot.Morning.ToString()));
            Assert.That(model?.Type, Is.EqualTo(DogActivityType.Short_Walk.ToString()));
            Assert.IsNotNull(model?.Walker);
            Assert.IsNotNull(model?.Dog);
        }

        [Test]
        public void ActivitiesExchange__DogActivity_Pack_NullObject_ReturnsNullObject()
        {
            DogActivity? dogActivity = null;

            Mock<IWalkersExchange> walkersExchange = new Mock<IWalkersExchange>();
            Mock<IDogsExchange> dogExchange = new Mock<IDogsExchange>();
            ActivitiesExchange activitiesExchange = new ActivitiesExchange(walkersExchange.Object, dogExchange.Object);
            DogActivityModel? model = activitiesExchange.Pack(dogActivity);

            Assert.IsNull(model);
        }

        [Test]
        public void ActivitiesExchange__DogActivityList_Pack_ValidList_ReturnsAValidModelList()
        {
            List<DogActivity> dogActivityList = new List<DogActivity>()
            {
                new DogActivity
                {
                    Id = AValidId,
                    Date = AValidDate,
                    Timeslot = AValidTimeslot,
                    Type = AValidDogActivityType,
                },
                new DogActivity
                {
                    Id = AValidId2,
                    Date = AValidDate,
                    Timeslot = AValidTimeslot2,
                    Type = AValidDogActivityType2,
                }
            };

            Mock<IWalkersExchange> walkersExchange = new Mock<IWalkersExchange>();
            walkersExchange.Setup(m => m.Pack(It.IsAny<Walker>())).Returns(AValidWalkerModel);
            Mock<IDogsExchange> dogsExchange = new Mock<IDogsExchange>();
            dogsExchange.Setup(m => m.Pack(It.IsAny<Dog>())).Returns(AValidDogModel);

            ActivitiesExchange activitiesExchange = new ActivitiesExchange(walkersExchange.Object, dogsExchange.Object);
            List<DogActivityModel?> modelList = activitiesExchange.Pack(dogActivityList).ToList();

            Assert.That(modelList, Is.Not.Empty);
            Assert.That(modelList[0]?.Id, Is.EqualTo(AValidId));
            Assert.That(modelList[0]?.Timeslot, Is.EqualTo(AValidTimeslot.ToString()));
            Assert.That(modelList[1]?.Id, Is.EqualTo(AValidId2));
            Assert.That(modelList[1]?.Timeslot, Is.EqualTo(AValidTimeslot2.ToString()));
        }

        [Test]
        public void ActivitiesExchange__DogActivityList_Pack_EmptyList_ReturnsNullObjectList()
        {
            List<DogActivity> dogActivityList = new List<DogActivity>();

            Mock<IWalkersExchange> walkersExchange = new Mock<IWalkersExchange>();
            Mock<IDogsExchange> dogsExchange = new Mock<IDogsExchange>();
            ActivitiesExchange activitiesExchange = new ActivitiesExchange(walkersExchange.Object, dogsExchange.Object);
            List<DogActivityModel?> modelList = activitiesExchange.Pack(dogActivityList).ToList();

            Assert.That(modelList, Is.Empty);
        }

        [Test]
        public void ActivitiesExchange__DogActivity_Unpack_ValidModel_ReturnsAValidObject() 
        {
            DogActivityCreationModel model = new DogActivityCreationModel 
            {
                Id = AValidId,
                DogId = AValidDogId,
                WalkerId = AValidWalkerId,
                Date = AValidDateString,
                Timeslot = AValidTimeslot.ToString(),
                Type = AValidDogActivityType.ToString()
            };

            Mock<IWalkersExchange> walkersExchange = new Mock<IWalkersExchange>();
            Mock<IDogsExchange> dogsExchange = new Mock<IDogsExchange>();
            ActivitiesExchange activitiesExchange = new ActivitiesExchange(walkersExchange.Object, dogsExchange.Object);
            DogActivity? dogActivity = activitiesExchange.Unpack(model);

            Assert.NotNull(dogActivity);
            Assert.That(dogActivity?.Id, Is.EqualTo(AValidId));
            Assert.That(dogActivity?.DogId, Is.EqualTo(AValidDogId));
            Assert.That(dogActivity?.WalkerId, Is.EqualTo(AValidWalkerId));
            Assert.That(dogActivity?.Date, Is.EqualTo(AValidDate));
            Assert.That(dogActivity?.Timeslot, Is.EqualTo(AValidTimeslot));
            Assert.That(dogActivity?.Type, Is.EqualTo(AValidDogActivityType));
        }

        [Test]
        public void ActivitiesExchange__DogActivity_Unpack_EmptyModel_ReturnsEmptyObject()
        {
            DogActivityCreationModel model = new DogActivityCreationModel();

            Mock<IWalkersExchange> walkersExchange = new Mock<IWalkersExchange>();
            Mock<IDogsExchange> dogsExchange = new Mock<IDogsExchange>();
            ActivitiesExchange activitiesExchange = new ActivitiesExchange(walkersExchange.Object, dogsExchange.Object);
            DogActivity? dogActivity = activitiesExchange.Unpack(model);

            Assert.NotNull(dogActivity);
            Assert.That(dogActivity?.Id, Is.EqualTo(0));
            Assert.That(dogActivity?.DogId, Is.EqualTo(0));
            Assert.That(dogActivity?.WalkerId, Is.EqualTo(0));
            Assert.That(dogActivity?.Date, Is.EqualTo(new DateTime()));
            Assert.That(dogActivity?.Timeslot, Is.EqualTo(Timeslot.Morning));
            Assert.That(dogActivity?.Type, Is.EqualTo(DogActivityType.Short_Walk));
        }

        [Test]
        public void ActivitiesExchange__DogActivity_Unpack_NullModel_ReturnsNullObject()
        {
            DogActivityCreationModel? model = null;

            Mock<IWalkersExchange> walkersExchange = new Mock<IWalkersExchange>();
            Mock<IDogsExchange> dogsExchange = new Mock<IDogsExchange>();
            ActivitiesExchange activitiesExchange = new ActivitiesExchange(walkersExchange.Object, dogsExchange.Object);
            DogActivity? dogActivity = activitiesExchange.Unpack(model);

            Assert.Null(dogActivity);
        }
    }
}
