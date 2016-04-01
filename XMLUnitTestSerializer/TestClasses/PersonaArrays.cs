using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLUnitTestSerializer.TestClasses
{
    public class PersonaArrays
    {
        public string Name;
        public int Age;
        public string[] TopAnime { get; set; }

        public PersonaArrays()
        {
            Name = "Alejandro";
            Age = 20;
            TopAnime = new[] {"DBZ", "Fairy Tail", "Bleach", "Saint Seiya", "Naruto", "Yugioh"};
        }
    }
}
