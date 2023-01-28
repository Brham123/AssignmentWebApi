namespace UnitTests.ControllerUnitTests
{
    using Moq;
    using PhoneBookApi.Controllers;
    using PhoneBookApi.Models.BusinessModels;
    using PhoneBookApi.Services.IService;

    [TestClass]
    public class CompanyControllerTests
    {
        private readonly Mock<ICompanyService> mockCompanyService = new();

        [TestMethod]
        public void CompanyController_Create_Success()
        {
            // Arrange
            var company = new CreateCompanyParameters()
            {
                CompanyName = "Test",
                RegistrationDate = DateTime.Now
            };

            this.mockCompanyService.Setup(x => x.CreateCompany(It.IsAny<CreateCompanyParameters>())).ReturnsAsync(true);
            var controller = new CompanyController(mockCompanyService.Object);

            // Act
            var actionResult = controller.Create(company);
            var response = actionResult.Result as OkObjectResult;

            // Assert
            Assert.AreEqual(response.StatusCode, (int)HttpStatusCode.OK);
            Assert.AreEqual(response.Value, true);
        }

        [TestMethod]
        public void CompanyController_Create_Fail()
        {
            // Arrange
            var company = new CreateCompanyParameters()
            {
                CompanyName = "Test",
                RegistrationDate = DateTime.Now
            };

            this.mockCompanyService.Setup(x => x.CreateCompany(It.IsAny<CreateCompanyParameters>())).ReturnsAsync(false);
            var controller = new CompanyController(mockCompanyService.Object);

            // Act
            var actionResult = controller.Create(company);
            var response = actionResult.Result as OkObjectResult;

            // Assert
            Assert.AreEqual(response.StatusCode, (int)HttpStatusCode.OK);
            Assert.AreEqual(response.Value, false);
        }

        [TestMethod]
        public void CompanyController_GetAllCompanies_Success()
        {
            // Arrange
            var listOfCompanies = new List<CompanyDetails>
            {
                new CompanyDetails
                {
                    CompanyId= 1,
                    CompanyName = "Test",
                    RegistrationDate = DateTime.Now,
                    NumberOfPersons= 0
                }
            };

            this.mockCompanyService.Setup(x => x.GetAll()).ReturnsAsync(listOfCompanies);
            var controller = new CompanyController(mockCompanyService.Object);

            // Act
            var actionResult = controller.GetAllCompanies();
            var response = actionResult.Result as OkObjectResult;
            var value = response.Value as List<CompanyDetails>;

            // Assert
            Assert.AreEqual(response.StatusCode, (int)HttpStatusCode.OK);
            Assert.AreEqual(value.Count, 1);
        }
    }
}
