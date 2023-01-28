namespace UnitTests.RepositoryTests
{
    using Microsoft.EntityFrameworkCore;
    using PhoneBookApi.Models.DataModels;
    using PhoneBookApi.Repositories.Repository;
    using System;

    [TestClass]
    public class CompanyRepositoryTests
    {
        private readonly DbContextOptions<PhoneBookContext> dbContextOptions;

        public CompanyRepositoryTests()
        {
            var dbName = $"PhoneBookDb_{DateTime.Now.ToFileTimeUtc()}";

            dbContextOptions = new DbContextOptionsBuilder<PhoneBookContext>()
                .UseInMemoryDatabase(dbName)
                .Options;
        }

        private async Task<CompanyRepository> CreateRepositoryAsync()
        {
            PhoneBookContext context = new PhoneBookContext(dbContextOptions);
            await PopulateDataAsync(context);
            return new CompanyRepository(context);
        }

        private async Task PopulateDataAsync(PhoneBookContext context)
        {
            var company = new Company()
            {
                Name = "Test",
                RegistrationDate = DateTime.Now
            };

            await context.Company.AddAsync(company);
            await context.SaveChangesAsync();
        }

        [TestMethod]
        public async Task CompanyRepository_GetAll_Success()
        {
            // Arrange
            var repository = await CreateRepositoryAsync();

            // Act
            var response = await repository.GetAll();

            // Assert
            Assert.IsTrue(response.Count == 1);
        }
    }
}
