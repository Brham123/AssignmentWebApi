using System;

namespace PhoneBookApi.Models.DataModels
{
    public partial class Company
    {
        public Company()
        {
            Person = new HashSet<Person>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime RegistrationDate { get; set; }

        public virtual ICollection<Person> Person { get; set; }
    }
}
