using BatteryConditionInventory.Core.SharedKernel;
using System.Collections.Generic;
using System.Linq;

namespace BatteryConditionInventory.Core.Entities
{
    public class BatteryCondition : BaseEntity
    {
        public int BatteryLocalId { get; set; }

        public int? BatteryModelId { get; set; }
        public BatteryModel BatteryModel { get; set; }
        // public string BatteryModelName { get { return BatteryModel.Battery + " " + BatteryModel.BatteryModelName; } }

        public ICollection<AddressByDate> AddressByDates { get; set; }
        public AddressByDate AddressByDateLast { get { return AddressByDates.Last(); } }

        public ICollection<CapacityByDate> CapacityByDates { get; set; }
        public CapacityByDate CapacityByDateLast { get { return CapacityByDates.Last(); } }

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