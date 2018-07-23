using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BatteryCondition.Models.ViewModels
{
    public class BatteryPackViewModel
    {
        public DateTime Date { get; set; }
        public string Address { get; set; }
        public BatteryPack BatteryPack { get; set; }
        public List<BatteryCondition> BatteryConditions { get; set; }
        // public List<DateTime> BatteryConditionDates { get; set; }

    }
}
