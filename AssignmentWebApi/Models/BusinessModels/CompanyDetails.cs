namespace PhoneBookApi.Models.BusinessModels
{
    public class CompanyDetails
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int NumberOfPersons { get; set; }
    }
}
