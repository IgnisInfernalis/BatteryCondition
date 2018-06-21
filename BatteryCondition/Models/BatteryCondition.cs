using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BatteryCondition.Models
{
    public class BatteryCondition
    {
        public BatteryModel BatteryModel { get; set; }
        public List<Address.AddressByDate> AddressByDates { get; set; }
        public List<CapacityByDate> CapacityByDates { get; set; }
    }
}
