using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLUnitTestSerializer.TestClasses
{
    public class PersonaArrayAddressNull
    {
        public string Name;
        public int Age;
        public double Salary { get; set; }
        public Address[] Addresses { get; set; }
        public DateTime Time { get; set; }

        public PersonaArrayAddressNull()
        {
            Name = "Alejandro";
            Age = 20;
            Salary = 56000.35;
            Addresses = new [] {null, 
                                new Address("Tegucigalpa", "Los Laureles", 8765)};
            Time = DateTime.Today;
        }
    }
}
