using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLUnitTestSerializer.TestClasses
{
    public class Persona
    {
        public string Nombre;
        public int Edad;

        public Persona()
        {
            this.Nombre = "Alejandro";
            Edad = 20;
            Direccion = "San Pedro Sula";
            Colonia = "Montecarlo";
        }

        public string Direccion { get; set; }
        public string Colonia { get; set; }
    }
}
