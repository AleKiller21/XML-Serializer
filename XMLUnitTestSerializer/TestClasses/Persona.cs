﻿
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
