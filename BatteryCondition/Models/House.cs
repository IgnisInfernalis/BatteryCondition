using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BatteryCondition.Models
{
    public class House
    {
        public int HouseId { get; set; }
        public string HouseNumber { get; set; }

        public int StreetId { get; set; }
        public Street Street { get; set; }

        public House (string houseNmber, Street street)
        {
            HouseNumber = houseNmber;
            Street = street;
        }
    }
}
