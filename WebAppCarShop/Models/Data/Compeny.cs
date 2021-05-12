using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCarShop.Models.Data
{
    public class Compeny
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Employee> Workers { get; set; }

        public Compeny()
        {
            Workers = new List<Employee>();
        }
    }
}
