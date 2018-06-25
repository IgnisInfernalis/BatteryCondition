using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace BatteryCondition.Models
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
        }
    }
}
