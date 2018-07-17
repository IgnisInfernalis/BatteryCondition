using System;
using System.Collections.Generic;
using System.Text;
using BatteryConditionInventory.Core.SharedKernel;

namespace BatteryConditionInventory.Core.Entities
{
    public class BatteryModel : BaseEntity
    {
        public string BatteryModelName { get; set; }
        public int BatteryCapacity { get; set; }

        public ICollection<BatteryCondition> BatteryConditions { get; set; }
        //Lazy Load
        //public virtual ICollection<BatteryCondition> BatteryConditions { get; set; }

        public int? BatteryBrandId { get; set; }
        public BatteryBrand BatteryBrand { get; set; }
    }
}
