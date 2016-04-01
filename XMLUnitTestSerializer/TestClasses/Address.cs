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

        public Address(string city, string homeAddress, int houseNumber)
        {
            City = city;
            HomeAddress = homeAddress;
            HouseNumber = houseNumber;
        }
    }
}
