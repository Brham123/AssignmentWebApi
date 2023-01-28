namespace PhoneBookApi.Repositories.Repository
{
    using PhoneBook.Repositories.Repository;
    using PhoneBookApi.Models.BusinessModels;
    using PhoneBookApi.Models.DataModels;
    using PhoneBookApi.Repositories.IRepository;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        private readonly PhoneBookContext _databaseContext;

        public PersonRepository(PhoneBookContext databaseContext) : base(databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<List<PersonDetails>> GetAllPersons()
        {
            var result = (from c in _databaseContext.Company
                          join p in _databaseContext.Person on c.Id equals p.CompanyId
                          select new PersonDetails
                          {
                              Id = p.Id,
                              FirstName = p.FirstName,
                              LastName = p.LastName,
                              PhoneNumber = p.PhoneNumber,
                              Address = p.Address,
                              CompanyName = c.Name
                          }).ToList();

            return result;
        }

        public async Task<List<PersonDetails>> Search(string searchText)
        {
            var result = (from c in _databaseContext.Company
                          join p in _databaseContext.Person on c.Id equals p.CompanyId
                          where p.FirstName.Contains(searchText) || p.LastName.Contains(searchText)
                          || p.PhoneNumber.Contains(searchText) || p.Address.Contains(searchText)
                          || c.Name.Contains(searchText)
                          select new PersonDetails
                          {
                              Id = p.Id,
                              FirstName = p.FirstName,
                              LastName = p.LastName,
                              PhoneNumber = p.PhoneNumber,
                              Address = p.Address,
                              CompanyName = c.Name
                          }).ToList();

            return result;
        }
    }
}
