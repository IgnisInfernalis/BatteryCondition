using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace BatteryCondition.Models
{   
    //[NotMapped]
    public class AddressByDate
    {
        public int AddressByDateId { get; set; }
        public House House { get; set; }
        public DateTime DateTime { get; set; }

        public int BatteryConditionId { get; set; }
        public BatteryCondition BatteryCondition { get; set; }
    }
}
