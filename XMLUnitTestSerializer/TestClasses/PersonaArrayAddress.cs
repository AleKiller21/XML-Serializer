using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLUnitTestSerializer.TestClasses
{
    public class PersonaArrayAddress
    {
        public string Name;
        public int Age;
        public double Salary { get; set; }
        public Address[] Addresses { get; set; }
        public DateTime Time { get; set; }

        public PersonaArrayAddress()
        {
            Name = "Alejandro";
            Age = 20;
            Salary = 56000.35;
            Addresses = new [] {new Address("San Pedro Sula", "Montecarlo", 5678), 
                                new Address("Tegucigalpa", "Los Laureles", 8765)};
            Time = DateTime.Today;
        }
    }
}
