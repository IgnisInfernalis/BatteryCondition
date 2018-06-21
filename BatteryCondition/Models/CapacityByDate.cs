using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BatteryCondition.Models
{
    public class CapacityByDate
    {
        public int CapacityByDateId { get; set; }
        public int Capacity { get; set; }
        public DateTime DateTime { get; set; }

    }
}
