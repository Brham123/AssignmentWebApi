namespace UnitTests.ServicesTests
{
    using PhoneBookApi.Models.BusinessModels;
    using PhoneBookApi.Models.DataModels;
    using PhoneBookApi.Repositories.IRepository;
    using PhoneBookApi.Services.Service;

    [TestClass]
    public class PersonServiceTests
    {
        private readonly Mock<IPersonRepository> mockPersonRepository = new();

        [TestMethod]
        public void PersonService_Create_Success()
        {
            // Arrange
            var person = new CreatePersonParameters()
            {
                CompanyId = 1,
                FirstName = "Test",
                LastName = "Test",
                PhoneNumber = "Test",
                Address = "test",
            };

            var service = new PersonService(mockPersonRepository.Object);

            // Act
            var response = service.CreatePerson(person);

            // Assert
            Assert.IsTrue(response.Result);
        }

        [TestMethod]
        public void PersonService_Delete_Success()
        {
            // Arrange
            var person = new Person()
            {
                Id = 1,
                CompanyId = 1,
                FirstName = "Test",
                LastName = "Test",
                PhoneNumber = "Test",
                Address = "test",
            };

            mockPersonRepository.Setup(x => x.Get(person.Id)).Returns(person);
            var service = new PersonService(mockPersonRepository.Object);

            // Act
            var response = service.DeletePerson(person.Id);

            // Assert
            Assert.IsTrue(response.Result);
        }

        [TestMethod]
        public void PersonService_Delete_Fail()
        {
            // Arrange
            var service = new PersonService(mockPersonRepository.Object);

            // Act
            var response = service.DeletePerson(1);

            // Assert
            Assert.IsFalse(response.Result);
        }

        [TestMethod]
        public void PersonService_GetAll_Success()
        {
            // Arrange
            var person = new PersonDetails()
            {
                Id = 1,
                CompanyName= "Test",
                FirstName = "Test",
                LastName = "Test",
                PhoneNumber = "Test",
                Address = "test",
            };

            mockPersonRepository.Setup(x => x.GetAllPersons()).ReturnsAsync(new List<PersonDetails> { person });
            var service = new PersonService(mockPersonRepository.Object);

            // Act
            var response = service.GetAll().Result;

            // Assert
            Assert.IsTrue(response.Count > 0);
        }

        [TestMethod]
        public void PersonService_GetRandomProfile_Success()
        {
            // Arrange
            var person = new PersonDetails()
            {
                Id = 1,
                CompanyName = "Test",
                FirstName = "Test",
                LastName = "Test",
                PhoneNumber = "Test",
                Address = "test",
            };

            mockPersonRepository.Setup(x => x.GetAllPersons()).ReturnsAsync(new List<PersonDetails> { person });
            var service = new PersonService(mockPersonRepository.Object);

            // Act
            var response = service.GetRandomProfile().Result;

            // Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void PersonService_Search_Success()
        {
            // Arrange
            var person = new PersonDetails()
            {
                Id = 1,
                CompanyName = "Test",
                FirstName = "Test",
                LastName = "Test",
                PhoneNumber = "Test",
                Address = "test",
            };

            mockPersonRepository.Setup(x => x.Search(It.IsAny<string>())).ReturnsAsync(new List<PersonDetails> { person });
            var service = new PersonService(mockPersonRepository.Object);

            // Act
            var response = service.Search("Demo").Result;

            // Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void PersonService_Update_Success()
        {
            // Arrange
            var person = new Person()
            {
                Id = 1,
                CompanyId = 1,
                FirstName = "Test",
                LastName = "Test",
                PhoneNumber = "Test",
                Address = "test",
            };

            var updatePerson = new CreatePersonParameters()
            {
                PersonId= 1,
                CompanyId = 1,
                FirstName = "Test",
                LastName = "Test",
                PhoneNumber = "Test",
                Address = "test",
            };

            mockPersonRepository.Setup(x => x.Get(person.Id)).Returns(person);
            var service = new PersonService(mockPersonRepository.Object);

            // Act
            var response = service.UpdatePerson(updatePerson);

            // Assert
            Assert.IsTrue(response.Result);
        }

        [TestMethod]
        public void PersonService_Update_Fail()
        {
            // Arrange
            var updatePerson = new CreatePersonParameters()
            {
                PersonId = 1,
                CompanyId = 1,
                FirstName = "Test",
                LastName = "Test",
                PhoneNumber = "Test",
                Address = "test",
            };

            var service = new PersonService(mockPersonRepository.Object);

            // Act
            var response = service.UpdatePerson(updatePerson);

            // Assert
            Assert.IsFalse(response.Result);
        }
    }
}
