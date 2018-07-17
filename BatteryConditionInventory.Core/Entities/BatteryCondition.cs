using BatteryConditionInventory.Core.SharedKernel;
using System.Collections.Generic;

namespace BatteryConditionInventory.Core.Entities
{
    public class BatteryCondition : BaseEntity
    {
        public int BatteryLocalId { get; set; }

        public int? BatteryModelId { get; set; }
        public BatteryModel BatteryModel { get; set; }

        public ICollection<AddressByDate> AddressByDates { get; set; }
        public ICollection<CapacityByDate> CapacityByDates { get; set; }
        public ICollection<BatteryConditionBatteryPack> 
            BatteryConditionBatteryPack { get; set; }
        //Lazy Load
        //public virtual ICollection<AddressByDate> AddressByDates { get; set; }
        //public virtual ICollection<CapacityByDate> CapacityByDates { get; set; }
        //public virtual ICollection<BatteryConditionBatteryPack> 
        //  BatteryConditionBatteryPack { get; set; }

        public BatteryCondition()
        {
            BatteryConditionBatteryPack = new List<BatteryConditionBatteryPack>();
        }
    }
}