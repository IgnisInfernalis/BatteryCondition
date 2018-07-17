using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BatteryConditionInventory.Infrastructure.Data;
using BatteryConditionInventory.Core.Entities;
using Microsoft.AspNetCore.Mvc;


namespace BatteryConditionInventory.Models
{
    public static class SampleData
    {
        public static void Initialize(BatteryContext context)
        {
            if (!context.Cities.Any())
            {
                context.Cities.AddRange(
                    new City { CityName = "Донецк" },
                    new City { CityName = "Севастополь" }
                    );                
            };
            context.SaveChanges();
            if (context.Cities.Any() && !context.Streets.Any())
            {
                context.Streets.AddRange(
                    new Street { StreetName = "бульвар Пушкина", City = context.Cities.ToList().Find(c => c.CityName == "Донецк") },
                    new Street { StreetName = "проспект Дзержинского", City = context.Cities.ToList().Find(c => c.CityName == "Донецк") },
                    new Street { StreetName = "улица Куйбышева", City = context.Cities.ToList().Find(c => c.CityName == "Донецк") }
                    );
            }
            context.SaveChanges();
            if (context.Streets.Any() && !context.Houses.Any())
            {
                context.Houses.AddRange(
                    new House { HouseNumber = "23", Street = context.Streets.ToList().Find(s => s.StreetName == "бульвар Пушкина") },
                    new House { HouseNumber = "49б", Street = context.Streets.ToList().Find(s => s.StreetName == "проспект Дзержинского") },
                    new House { HouseNumber = "240а", Street = context.Streets.ToList().Find(s => s.StreetName == "улица Куйбышева") }
                    );
            }
            context.SaveChanges();
            if (!context.Brands.Any())
            {
                context.Brands.AddRange(
                    new BatteryBrand { BatteryBrandName = "Sunlight" },
                    new BatteryBrand { BatteryBrandName = "Leoch" },
                    new BatteryBrand { BatteryBrandName = "Delta" },
                    new BatteryBrand { BatteryBrandName = "X-Digital" },
                    new BatteryBrand { BatteryBrandName = "Ventura" },
                    new BatteryBrand { BatteryBrandName = "Vision" },
                    new BatteryBrand { BatteryBrandName = "CSB" }
                    );
            }
            context.SaveChanges();
            if (context.Brands.Any() && !context.BatteryModels.Any())
            {
                context.BatteryModels.AddRange(
                    new BatteryModel { BatteryModelName = "DJM12100", BatteryCapacity = 100, BatteryBrand = context.Brands.ToList().Find(b => b.BatteryBrandName == "Leoch") },
                    new BatteryModel { BatteryModelName = "DJM12120", BatteryCapacity = 120, BatteryBrand = context.Brands.ToList().Find(b => b.BatteryBrandName == "Leoch") },
                    new BatteryModel { BatteryModelName = "SPB 12-120", BatteryCapacity = 120, BatteryBrand = context.Brands.ToList().Find(b => b.BatteryBrandName == "X-Digital") },
                    new BatteryModel { BatteryModelName = "SPB 12-120", BatteryCapacity = 120, BatteryBrand = context.Brands.ToList().Find(b => b.BatteryBrandName == "Sunlight") },
                    new BatteryModel { BatteryModelName = "DTM 12120", BatteryCapacity = 120, BatteryBrand = context.Brands.ToList().Find(b => b.BatteryBrandName == "Delta") }
                    );
            }
            context.SaveChanges();
            if (!context.AddressByDates.Any())
            {
                context.AddressByDates.AddRange(
                    new AddressByDate { House = context.Houses.ToList().Find(h => h.HouseNumber == "240а"), DateTime = DateTime.Today,
                        BatteryCondition =new BatteryCondition
                        {                            
                            BatteryLocalId = 110,
                            BatteryModel = context.BatteryModels.ToList().Find(b => b.BatteryBrand == (context.Brands.ToList().Find(bb => bb.BatteryBrandName == "Delta"))
                            && b.BatteryModelName == "DTM 12120")
                        } }
                    );
            }
            context.SaveChanges();
            if (!context.BatteryPacks.Any())
            {
                context.BatteryPacks.Add(
                    new BatteryPack { AddressByDate=context.AddressByDates.ToList().Find(a=>a.House == (context.Houses.ToList().Find(h => h.HouseNumber == "240а"))) }
                    );
            }
            context.SaveChanges();

        }
    }
}
