using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BatteryCondition.Models
{
    public class BatteryPack
    {
        public int BatteryPackId { get; set; }
        public AddressByDate AddressByDates { get; set; }
        public List<BatteryCondition> BatteryConditions { get; set; }
    }
}
