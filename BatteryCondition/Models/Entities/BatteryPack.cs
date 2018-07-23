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
        // связь многие-ко-многим
        public ICollection<BatteryConditionBatteryPack> BatteryConditionBatteryPacks { get; set; }

        public BatteryPack()
        {
            BatteryConditionBatteryPacks = new List<BatteryConditionBatteryPack>();
        }
    }
}
