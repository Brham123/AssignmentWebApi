namespace UnitTests.ServicesTests
{
    using PhoneBookApi.Models.BusinessModels;
    using PhoneBookApi.Repositories.IRepository;
    using PhoneBookApi.Services.Service;

    [TestClass]
    public class CompanyServiceTests
    {
        private readonly Mock<ICompanyRepository> mockCompanyRepository = new();

        [TestMethod]
        public void CompanyService_Create_Success()
        {
            // Arrange
            var company = new CreateCompanyParameters()
            {
                CompanyName = "Test12",
                RegistrationDate = DateTime.Now
            };

            mockCompanyRepository.Setup(x => x.GetAll()).ReturnsAsync(new List<CompanyDetails>
            {
                new CompanyDetails
                {
                    CompanyId= 1,
                    CompanyName = "Test"
                }
            });

            var service = new CompanyService(mockCompanyRepository.Object);

            // Act
            var response = service.CreateCompany(company);

            // Assert
            Assert.IsTrue(response.Result);
        }

        [TestMethod]
        public void CompanyService_DuplicateName_Fail()
        {
            // Arrange
            var company = new CreateCompanyParameters()
            {
                CompanyName = "Test",
                RegistrationDate = DateTime.Now
            };

            mockCompanyRepository.Setup(x => x.GetAll()).ReturnsAsync(new List<CompanyDetails>
            {
                new CompanyDetails
                {
                    CompanyId= 1,
                    CompanyName = "Test"
                }
            });

            var service = new CompanyService(mockCompanyRepository.Object);

            // Act
            var response = service.CreateCompany(company);

            // Assert
            Assert.IsFalse(response.Result);
        }

        [TestMethod]
        public void CompanyService_GetAll_Success()
        {
            // Arrange
            var company = new CreateCompanyParameters()
            {
                CompanyName = "Test",
                RegistrationDate = DateTime.Now
            };

            mockCompanyRepository.Setup(x => x.GetAll()).ReturnsAsync(new List<CompanyDetails>
            {
                new CompanyDetails
                {
                    CompanyId= 1,
                    CompanyName = "Test"
                }
            });

            var service = new CompanyService(mockCompanyRepository.Object);

            // Act
            var response = service.GetAll().Result;

            // Assert
            Assert.IsTrue(response.Count == 1);
        }
    }
}
