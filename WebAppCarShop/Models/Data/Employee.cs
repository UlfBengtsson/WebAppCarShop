using System.Collections.Generic;

namespace WebAppCarShop.Models.Data
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Phone> PhoneNumbers { get; set; }

        public Employee()
        {
            PhoneNumbers = new List<Phone>();
        }
    }
}