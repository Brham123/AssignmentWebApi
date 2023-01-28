namespace PhoneBookApi.Services.IService
{
    using PhoneBookApi.Models.BusinessModels;

    public interface ICompanyService
    {
        Task<bool> CreateCompany(CreateCompanyParameters createCompanyParameters);
        Task<List<CompanyDetails>> GetAll();
    }
}
