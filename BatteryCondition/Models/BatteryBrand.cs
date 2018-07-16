using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BatteryConditionsInventory.Models
{
    public class BatteryBrand
    {
        public int BatteryBrandId { get; set; }
        public string BatteryBrandName { get; set; }

        public virtual ICollection<BatteryModel> BatteryModels { get; set; }
    }
}
