using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BatteryCondition.Models.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<BatteryPack> BatteryPacks { get; set; }
        public IEnumerable<BatteryModel> BatteryModels { get; set; }
        
    }
}
