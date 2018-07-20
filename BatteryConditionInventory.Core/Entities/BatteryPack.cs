using System.Collections.Generic;
using BatteryConditionInventory.Core.SharedKernel;

namespace BatteryConditionInventory.Core.Entities
{
    public class BatteryPack : BaseEntity
    {
        public AddressByDate AddressByDate { get; set; }

        // Связь многие-ко-многим
        public ICollection<BatteryConditionBatteryPack> 
            BatteryConditionBatteryPacks { get; set; }

        //Lazy Load
        //public virtual ICollection<BatteryConditionBatteryPack> BatteryConditionBatteryPacks { get; set; }

        public BatteryPack()
        {
            BatteryConditionBatteryPacks = new List<BatteryConditionBatteryPack>();
        }
    }
}