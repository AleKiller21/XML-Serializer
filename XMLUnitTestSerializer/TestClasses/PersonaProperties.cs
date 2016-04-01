using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLUnitTestSerializer.TestClasses
{
    public class PersonaProperties
    {
        public int NumCuenta { get; set; }
        public string Universidad { get; set; }

        public PersonaProperties()
        {
            NumCuenta = 21351064;
            Universidad = "Unitec";
        }
    }
}
