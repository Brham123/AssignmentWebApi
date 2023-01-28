namespace PhoneBookApi.Repositories.Repository
{
    using Microsoft.EntityFrameworkCore;
    using PhoneBook.Repositories.Repository;
    using PhoneBookApi.Models.BusinessModels;
    using PhoneBookApi.Models.DataModels;
    using PhoneBookApi.Repositories.IRepository;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        private readonly PhoneBookContext _databaseContext;

        public CompanyRepository(PhoneBookContext databaseContext) : base(databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<List<CompanyDetails>> GetAll()
        {
            var companyDetails = _databaseContext.Company.Include(x => x.Person).Select(x => new CompanyDetails
            {
                CompanyId = x.Id,
                CompanyName = x.Name,
                RegistrationDate = x.RegistrationDate,
                NumberOfPersons = x.Person.Count
            }).ToList();

            return companyDetails;
        }
    }
}
