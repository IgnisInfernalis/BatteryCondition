using System.Collections.Generic;
using BatteryConditionInventory.Core.SharedKernel;

namespace BatteryConditionInventory.Core.Entities
{
    public class BatteryBrand : BaseEntity
    {
        public string BatteryBrandName { get; set; }

        public ICollection<BatteryModel> BatteryModels { get; set; }
        //Lazy Load
        //public virtual ICollection<BatteryModel> BatteryModels { get; set; }
    }
}