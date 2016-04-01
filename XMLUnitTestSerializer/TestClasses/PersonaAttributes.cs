using System;
using System.Collections.Generic;
using XMLSerializerLogic.Attributes;

namespace XMLUnitTestSerializer.TestClasses
{
    public class PersonaAttributes
    {
        [XmlName("Goku")]
        public string Nombre { get; set; }
        public int Edad;

        public PersonaAttributes()
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
