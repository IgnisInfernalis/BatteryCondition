using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BatteryCondition.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BatteryCondition.Models.GetViewModels
{
    public static class GetBatteryConditionViewModel
    {
        public static BatteryConditionViewModel GetViewModel(BatteryContext context, int Id)
        {
            var batteryCondition = context.BatteryConditions.Include(bc => bc.BatteryModel.BatteryBrand)
                .Include(bc =>bc.AddressByDates)
                    .ThenInclude(ad=>ad.House.Street)
                .Include(bc => bc.BatteryConditionBatteryPacks)
                    .ThenInclude(bp=>bp.BatteryPack.AddressByDate.House.Street)
                .Include(bc => bc.CapacityByDates)
                .FirstOrDefault(bc => bc.BatteryConditionId == Id);

            BatteryConditionViewModel batteryConditionViewModel = new BatteryConditionViewModel
            {
                BatteryLocalId = batteryCondition.BatteryLocalId,
                BatteryModelName = batteryCondition.BatteryModel.BatteryModelName,
                BatteryBrandName = batteryCondition.BatteryModel.BatteryBrand.BatteryBrandName,
                LastBatteryPack = batteryCondition.BatteryConditionBatteryPacks.LastOrDefault().BatteryPack,
                BatteryModelCapacity = batteryCondition.BatteryModel.BatteryCapacity,
                LastDate = batteryCondition.AddressByDates.LastOrDefault().Date,
                LastCapacity = batteryCondition.CapacityByDates.LastOrDefault()?.Capacity ?? 
                                   0,
                LastCapacityDate = batteryCondition.CapacityByDates.LastOrDefault()?.Date ??
                                   batteryCondition.AddressByDates.LastOrDefault().Date.Date,

                AddressByDates = batteryCondition.AddressByDates.ToList(),
                CapacityByDates = batteryCondition.CapacityByDates.ToList()
            };

            return batteryConditionViewModel;
        }
    }
}
