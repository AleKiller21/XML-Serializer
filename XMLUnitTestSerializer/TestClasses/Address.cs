using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLUnitTestSerializer.TestClasses
{
    public class Address
    {
        public string City;
        public string HomeAddress;
        public int HouseNumber { get; set; }

        public Address()
        {
            City = "San Pedro Sula";
            HomeAddress = "Col. Montecarlo";
            HouseNumber = 5678;
        }
    }
}
