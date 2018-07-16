using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BatteryConditionInventory.Models
{
    public class BatteryConditionBatteryPack
    {
        public int BatteryConditionId { get; set; }
        public BatteryCondition BatteryCondition { get; set; }

        public int BatteryPackId { get; set; }
        public BatteryPack BatteryPack { get; set; }
    }
}
