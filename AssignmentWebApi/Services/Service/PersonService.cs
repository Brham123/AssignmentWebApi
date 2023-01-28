namespace PhoneBookApi.Services.Service
{
    using PhoneBookApi.Models.BusinessModels;
    using PhoneBookApi.Models.DataModels;
    using PhoneBookApi.Repositories.IRepository;
    using PhoneBookApi.Services.IService;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<bool> CreatePerson(CreatePersonParameters createPersonParameters)
        {
            var person = new Person
            {
                FirstName = createPersonParameters.FirstName,
                LastName = createPersonParameters.LastName,
                PhoneNumber = createPersonParameters.PhoneNumber,
                Address = createPersonParameters.Address,
                CompanyId = createPersonParameters.CompanyId
            };

            _personRepository.Add(person);

            return true;
        }

        public async Task<bool> DeletePerson(int personId)
        {
            var person = _personRepository.Get(personId);

            if (person != null)
            {
                _personRepository.Remove(person);
                return true;
            }

            return false;
        }

        public async Task<List<PersonDetails>> GetAll()
        {
            var result = await _personRepository.GetAllPersons();

            return result;
        }

        public async Task<PersonDetails> GetRandomProfile()
        {
            var random = new Random();

            var result = await _personRepository.GetAllPersons();
            int index = random.Next(result.Count);

            return result[index];
        }

        public async Task<List<PersonDetails>> Search(string searchText)
        {
            var result = await _personRepository.Search(searchText);

            return result;
        }

        public async Task<bool> UpdatePerson(CreatePersonParameters createPersonParameters)
        {
            var person = _personRepository.Get(createPersonParameters.PersonId);

            if (person != null)
            {
                person.FirstName = createPersonParameters.FirstName;
                person.LastName = createPersonParameters.LastName;
                person.PhoneNumber = createPersonParameters.PhoneNumber;
                person.Address = createPersonParameters.Address;
                person.CompanyId = createPersonParameters.CompanyId;

                _personRepository.Update(person);

                return true;
            }

            return false;
        }
    }
}
