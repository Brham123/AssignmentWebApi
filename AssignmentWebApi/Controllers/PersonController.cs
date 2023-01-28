namespace PhoneBookApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PhoneBookApi.Models.BusinessModels;
    using PhoneBookApi.Services.IService;

    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost]
        [Route("GetAll")]
        public async Task<ActionResult> GetAllPersons()
        {
            var result = await _personService.GetAll();

            return this.Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreatePersonParameters createPersonParameters)
        {
            var result = await _personService.CreatePerson(createPersonParameters);

            return this.Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Update(CreatePersonParameters createPersonParameters)
        {
            var result = await _personService.UpdatePerson(createPersonParameters);

            return this.Ok(result);
        }

        [HttpGet]
        [Route("GetRandomPerson")]
        public async Task<ActionResult> GetRandomPerson()
        {
            var result = await _personService.GetRandomProfile();

            return this.Ok(result);
        }

        [HttpDelete("{personId}")]
        public async Task<ActionResult> Delete(int personId)
        {
            var result = await _personService.DeletePerson(personId);

            return this.Ok(result);
        }

        [HttpGet("{textToSearch}")]
        public async Task<ActionResult> Search(string textToSearch)
        {
            var result = await _personService.Search(textToSearch);

            return this.Ok(result);
        }
    }
}
