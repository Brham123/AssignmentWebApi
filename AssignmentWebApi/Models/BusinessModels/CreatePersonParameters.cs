namespace PhoneBookApi.Models.BusinessModels
{
    public class CreatePersonParameters
    {
        public int PersonId { get; set; }
        public int CompanyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
