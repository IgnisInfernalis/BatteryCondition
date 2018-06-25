using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BatteryCondition.Models
{
    public class Street
    {
        public int StreetId { get; set; }
        public string StreetName { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }

        // public Street() { }
        /*public Street(string streetName, City city)
        {
            StreetName = streetName;
            //CityId = city.CityId;
            City = city;
        }*/
    }
}
