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
                .Include(bc => bc.AddressByDates)
                    .ThenInclude(ad=>ad.House.Street)
                .Include(bc => bc.BatteryConditionBatteryPacks)
                    .ThenInclude(bp=>bp.BatteryPack.AddressByDate.House.Street)
                .Include(bc => bc.CapacityByDates)
                .FirstOrDefault(bc => bc.BatteryConditionId == Id);

            BatteryConditionViewModel batteryConditionViewModel = new BatteryConditionViewModel();

            batteryConditionViewModel.BatteryLocalId = batteryCondition.BatteryLocalId;
            batteryConditionViewModel.BatteryModelName = batteryCondition.BatteryModel.BatteryModelName;
            batteryConditionViewModel.BatteryBrandName = batteryCondition.BatteryModel.BatteryBrand.BatteryBrandName;
            batteryConditionViewModel.LastBatteryPack = batteryCondition.BatteryConditionBatteryPacks.LastOrDefault().BatteryPack;
            batteryConditionViewModel.LastDate = batteryCondition.AddressByDates.LastOrDefault().Date;
            batteryConditionViewModel.LastCapacity = batteryCondition.CapacityByDates.LastOrDefault().Capacity;
            batteryConditionViewModel.LastCapacityDate = batteryCondition.CapacityByDates.LastOrDefault().Date;

            batteryConditionViewModel.AddressByDates = batteryCondition.AddressByDates.ToList();
            batteryConditionViewModel.CapacityByDates = batteryCondition.CapacityByDates.ToList();

            return batteryConditionViewModel;
        }
    }
}
