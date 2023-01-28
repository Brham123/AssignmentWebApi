namespace UnitTests.ControllerUnitTests
{
    using PhoneBookApi.Controllers;
    using PhoneBookApi.Models.BusinessModels;
    using PhoneBookApi.Services.IService;

    [TestClass]
    public class PersonControllerTests
    {
        private readonly Mock<IPersonService> mockPersonService = new();

        [TestMethod]
        public void PersonController_Create_Success()
        {
            // Arrange
            var person = new CreatePersonParameters()
            {
                CompanyId = 1,
                FirstName = "FirstName",
                LastName = "LastName",
                PhoneNumber = "99999999",
                Address = "India"
            };

            this.mockPersonService.Setup(x => x.CreatePerson(It.IsAny<CreatePersonParameters>())).ReturnsAsync(true);
            var controller = new PersonController(mockPersonService.Object);

            // Act
            var actionResult = controller.Create(person);
            var response = actionResult.Result as OkObjectResult;

            // Assert
            Assert.AreEqual(response.StatusCode, (int)HttpStatusCode.OK);
            Assert.AreEqual(response.Value, true);
        }

        [TestMethod]
        public void PersonController_Create_Fail()
        {
            // Arrange
            var person = new CreatePersonParameters()
            {
                CompanyId = 1,
                FirstName = "FirstName",
                LastName = "LastName",
                PhoneNumber = "99999999",
                Address = "India"
            };

            this.mockPersonService.Setup(x => x.CreatePerson(It.IsAny<CreatePersonParameters>())).ReturnsAsync(false);
            var controller = new PersonController(mockPersonService.Object);

            // Act
            var actionResult = controller.Create(person);
            var response = actionResult.Result as OkObjectResult;

            // Assert
            Assert.AreEqual(response.StatusCode, (int)HttpStatusCode.OK);
            Assert.AreEqual(response.Value, false);
        }

        [TestMethod]
        public void PersonController_Update_Success()
        {
            // Arrange
            var person = new CreatePersonParameters()
            {
                PersonId= 1,
                CompanyId = 1,
                FirstName = "FirstName",
                LastName = "LastName",
                PhoneNumber = "99999999",
                Address = "India"
            };

            this.mockPersonService.Setup(x => x.UpdatePerson(It.IsAny<CreatePersonParameters>())).ReturnsAsync(true);
            var controller = new PersonController(mockPersonService.Object);

            // Act
            var actionResult = controller.Update(person);
            var response = actionResult.Result as OkObjectResult;

            // Assert
            Assert.AreEqual(response.StatusCode, (int)HttpStatusCode.OK);
            Assert.AreEqual(response.Value, true);
        }

        [TestMethod]
        public void PersonController_Update_Fail()
        {
            // Arrange
            var person = new CreatePersonParameters()
            {
                PersonId = 1,
                CompanyId = 1,
                FirstName = "FirstName",
                LastName = "LastName",
                PhoneNumber = "99999999",
                Address = "India"
            };

            this.mockPersonService.Setup(x => x.UpdatePerson(It.IsAny<CreatePersonParameters>())).ReturnsAsync(false);
            var controller = new PersonController(mockPersonService.Object);

            // Act
            var actionResult = controller.Update(person);
            var response = actionResult.Result as OkObjectResult;

            // Assert
            Assert.AreEqual(response.StatusCode, (int)HttpStatusCode.OK);
            Assert.AreEqual(response.Value, false);
        }

        [TestMethod]
        public void PersonController_Delete_Success()
        {
            // Arrange
            this.mockPersonService.Setup(x => x.DeletePerson(It.IsAny<int>())).ReturnsAsync(true);
            var controller = new PersonController(mockPersonService.Object);

            // Act
            var actionResult = controller.Delete(1);
            var response = actionResult.Result as OkObjectResult;

            // Assert
            Assert.AreEqual(response.StatusCode, (int)HttpStatusCode.OK);
            Assert.AreEqual(response.Value, true);
        }

        [TestMethod]
        public void PersonController_Delete_Fail()
        {
            // Arrange
            this.mockPersonService.Setup(x => x.DeletePerson(It.IsAny<int>())).ReturnsAsync(false);
            var controller = new PersonController(mockPersonService.Object);

            // Act
            var actionResult = controller.Delete(1);
            var response = actionResult.Result as OkObjectResult;

            // Assert
            Assert.AreEqual(response.StatusCode, (int)HttpStatusCode.OK);
            Assert.AreEqual(response.Value, false);
        }

        [TestMethod]
        public void PersonController_GetAllPersons_Success()
        {
            // Arrange
            var listOfPersons = new List<PersonDetails>
            {
                new PersonDetails
                {
                    Id= 1,
                    CompanyName = "CompanyName",
                    FirstName = "FirstName",
                    LastName = "LastName",
                    PhoneNumber = "PhoneNumber",
                    Address="Addres"
                }
            };

            this.mockPersonService.Setup(x => x.GetAll()).ReturnsAsync(listOfPersons);
            var controller = new PersonController(mockPersonService.Object);

            // Act
            var actionResult = controller.GetAllPersons();
            var response = actionResult.Result as OkObjectResult;
            var value = response.Value as List<PersonDetails>;

            // Assert
            Assert.AreEqual(response.StatusCode, (int)HttpStatusCode.OK);
            Assert.AreEqual(value.Count, 1);
        }

        [TestMethod]
        public void PersonController_Search_Success()
        {
            // Arrange
            var listOfPersons = new List<PersonDetails>
            {
                new PersonDetails
                {
                    Id= 1,
                    CompanyName = "CompanyName",
                    FirstName = "FirstName",
                    LastName = "LastName",
                    PhoneNumber = "PhoneNumber",
                    Address="Addres"
                }
            };

            this.mockPersonService.Setup(x => x.Search(It.IsAny<string>())).ReturnsAsync(listOfPersons);
            var controller = new PersonController(mockPersonService.Object);

            // Act
            var actionResult = controller.Search("Search");
            var response = actionResult.Result as OkObjectResult;
            var value = response.Value as List<PersonDetails>;

            // Assert
            Assert.AreEqual(response.StatusCode, (int)HttpStatusCode.OK);
            Assert.AreEqual(value.Count, 1);
        }

        [TestMethod]
        public void PersonController_GetRandomProfile_Success()
        {
            // Arrange
            var personDetails = new PersonDetails
            {
                Id = 1,
                CompanyName = "CompanyName",
                FirstName = "FirstName",
                LastName = "LastName",
                PhoneNumber = "PhoneNumber",
                Address = "Addres"
            };

            this.mockPersonService.Setup(x => x.GetRandomProfile()).ReturnsAsync(personDetails);
            var controller = new PersonController(mockPersonService.Object);

            // Act
            var actionResult = controller.GetRandomPerson();
            var response = actionResult.Result as OkObjectResult;
            var value = response.Value as PersonDetails;

            // Assert
            Assert.AreEqual(response.StatusCode, (int)HttpStatusCode.OK);
            Assert.AreEqual(value.FirstName, personDetails.FirstName);
        }
    }
}
