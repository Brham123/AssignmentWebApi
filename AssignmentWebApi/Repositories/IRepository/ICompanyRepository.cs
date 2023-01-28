namespace PhoneBookApi.Repositories.IRepository
{
    using PhoneBook.Repositories.IRepository;
    using PhoneBookApi.Models.BusinessModels;
    using PhoneBookApi.Models.DataModels;

    public interface ICompanyRepository : IBaseRepository<Company>
    {
        Task<List<CompanyDetails>> GetAll();
    }
}
