namespace UnitTests.RepositoryTests
{
    using Microsoft.EntityFrameworkCore;
    using PhoneBookApi.Models.DataModels;
    using PhoneBookApi.Repositories.Repository;
    using System;

    [TestClass]
    public class PersonRepositoryTests
    {
        private readonly DbContextOptions<PhoneBookContext> dbContextOptions;

        public PersonRepositoryTests()
        {
            var dbName = $"PhoneBookDb_{DateTime.Now.ToFileTimeUtc()}";

            dbContextOptions = new DbContextOptionsBuilder<PhoneBookContext>()
                .UseInMemoryDatabase(dbName)
                .Options;
        }

        private async Task<PersonRepository> CreateRepositoryAsync()
        {
            PhoneBookContext context = new PhoneBookContext(dbContextOptions);
            await PopulateDataAsync(context);
            return new PersonRepository(context);
        }

        private async Task PopulateDataAsync(PhoneBookContext context)
        {
            var company = new Company()
            {
                Name = "Test",
                RegistrationDate = DateTime.Now
            };

            var result = await context.Company.AddAsync(company);
            await context.SaveChangesAsync();

            var person = new Person()
            {
                CompanyId = result.Entity.Id,
                FirstName = "Test",
                LastName = "Test",
                PhoneNumber = "test",
                Address = "address",
            };

            await context.Person.AddAsync(person);
            await context.SaveChangesAsync();
        }

        [TestMethod]
        public async Task PersonRepository_GetAll_Success()
        {
            // Arrange
            var repository = await CreateRepositoryAsync();

            // Act
            var response = await repository.GetAllPersons();

            // Assert
            Assert.IsTrue(response.Count == 1);
        }

        [TestMethod]
        public async Task PersonRepository_Search_Success()
        {
            // Arrange
            var repository = await CreateRepositoryAsync();

            // Act
            var response = await repository.Search("Test");

            // Assert
            Assert.IsTrue(response.Count == 1);
        }
    }
}
