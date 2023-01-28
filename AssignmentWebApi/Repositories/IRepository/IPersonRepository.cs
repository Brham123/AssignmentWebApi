namespace PhoneBookApi.Repositories.IRepository
{
    using PhoneBook.Repositories.IRepository;
    using PhoneBookApi.Models.BusinessModels;
    using PhoneBookApi.Models.DataModels;

    public interface IPersonRepository : IBaseRepository<Person>
    {
        Task<List<PersonDetails>> GetAllPersons();

        Task<List<PersonDetails>> Search(string searchText);
    }
}
