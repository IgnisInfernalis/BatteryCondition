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

        public City City { get; set; }  // односторонняя связь один-ко-многим

    }
}
