using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BatteryCondition.Models
{
    public class BatteryPack
    {
        public int BatteryPackId { get; set; }
        public AddressByDate AddressByDate { get; set; }
        // public virtual List<BatteryCondition> BatteryConditions { get; set; }

        public virtual List<BatteryConditionBatteryPack> BatteryConditionBatteryPacks { get; set; }
        /*public BatteryPack()
        {
            BatteryConditions = new List<BatteryCondition>();
        }*/
    }
}
