namespace PhoneBookApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PhoneBookApi.Models.BusinessModels;
    using PhoneBookApi.Services.IService;

    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost]
        [Route("GetAll")]
        public async Task<ActionResult> GetAllCompanies()
        {
            var result = await _companyService.GetAll();

            return this.Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateCompanyParameters createCompanyParameters)
        {
            var result = await _companyService.CreateCompany(createCompanyParameters);

            return this.Ok(result);
        }
    }
}
