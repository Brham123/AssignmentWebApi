namespace PhoneBookApi.Services.IService
{
    using PhoneBookApi.Models.BusinessModels;

    public interface IPersonService
    {
        Task<bool> CreatePerson(CreatePersonParameters createPersonParameters);
        Task<bool> UpdatePerson(CreatePersonParameters createPersonParameters);
        Task<bool> DeletePerson(int personId);
        Task<List<PersonDetails>> GetAll();
        Task<PersonDetails> GetRandomProfile();
        Task<List<PersonDetails>> Search(string searchText);
    }
}
