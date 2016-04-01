using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLUnitTestSerializer.TestClasses
{
    public class PersonaAddress
    {
        public string Name;
        public string Genre;
        public Address address { get; set; }

        public PersonaAddress()
        {
            Name = "Alejandro";
            Genre = "Male";
            address = new Address("San Pedro Sula", "Col. Montecarlo", 5678);
        }
    }
}
