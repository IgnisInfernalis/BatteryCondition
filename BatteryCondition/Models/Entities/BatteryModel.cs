using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BatteryCondition.Models
{
    public class BatteryModel
    {
        public int BatteryModelId { get; set; }
        public string BatteryModelName { get; set; }
        public int BatteryCapacity { get; set; }

        public ICollection<BatteryCondition> BatteryConditions { get; set; }

        public int? BatteryBrandId { get; set; }
        public BatteryBrand BatteryBrand { get; set; }
    }
}
