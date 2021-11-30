using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanteenManagement.Models
{
    public class Test
    {
        public Employee createGuy(string name, DateTime birthday)
        {
            return new Employee { Name = name, Birthday= birthday};
        }

        public void start()
        {
            DateTime dateTime = DateTime.Now;
            Employee e = createGuy("Bob", dateTime);
        }
    }
    public class Employee
    {
        public DateTime Birthday { get; set; }
        public string Name { get; set; }
    }
}
