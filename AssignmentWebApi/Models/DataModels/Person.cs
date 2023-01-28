namespace PhoneBookApi.Models.DataModels
{
    public partial class Person
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public virtual Company Company { get; set; }
    }
}
