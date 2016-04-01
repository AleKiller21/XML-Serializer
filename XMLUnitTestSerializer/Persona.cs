using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLUnitTestSerializer
{
    public class Persona
    {
        public string Nombre;
        public int Edad;
        public int NumCuenta { get; set; }

        public Persona()
        {
            Nombre = "Ale";
            Edad = 20;
            NumCuenta = 21351064;
        }
    }
}
