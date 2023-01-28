namespace PhoneBookApi.Models.BusinessModels
{
    public class PersonDetails
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public string CompanyName { get; set; }
    }
}
