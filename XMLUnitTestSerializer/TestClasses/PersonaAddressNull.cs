using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLUnitTestSerializer.TestClasses
{
    public class PersonaAddressNull
    {
        public string Name;
        public string Genre;
        public Address address { get; set; }

        public PersonaAddressNull()
        {
            Name = "Alejandro";
            Genre = "Male";
            address = null;
        }
    }
}
