namespace PhoneBookApi.Services.Service
{
    using PhoneBookApi.Models.BusinessModels;
    using PhoneBookApi.Models.DataModels;
    using PhoneBookApi.Repositories.IRepository;
    using PhoneBookApi.Services.IService;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Linq;

    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<bool> CreateCompany(CreateCompanyParameters createCompanyParameters)
        {
            var company = _companyRepository.GetAll().Result.Where(x => x.CompanyName == createCompanyParameters.CompanyName).FirstOrDefault();

            if (company == null)
            {
                var newCompany = new Company()
                {
                    Name = createCompanyParameters.CompanyName,
                    RegistrationDate = createCompanyParameters.RegistrationDate
                };

                _companyRepository.Add(newCompany);

                return true;
            }

            return false;
        }

        public async Task<List<CompanyDetails>> GetAll()
        {
            var companyDetails = await _companyRepository.GetAll();

            return companyDetails;
        }
    }
}
