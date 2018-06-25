using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BatteryCondition.Models;

namespace BatteryCondition.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        /*
        List<Models.BatteryCondition> batteryConditions;
        List<BatteryPack> batteryPacks;
        List<BatteryModel> batteryModels;
        List<BatteryBrand> batteryBrands;
        List<AddressByDate> addressByDates;
        List<City> cities;
        List<Street> streets;
        List<House> houses;
        public HomeController()
        {
            cities = new List<City> { new City("Донецк") };
            streets = new List<Street> { new Street("бульвар Пушкина", cities.Find(c => c.CityName == "Донецк")),
                                         new Street("проспект Дзержинского", cities.Find(c => c.CityName=="Донецк")),
                                         new Street("улица Куйбышева", cities.Find(c => c.CityName=="Донецк")) };
            houses = new List<House> { new House("23", streets.Find(s => s.StreetName == "бульвар Пушкина")),
                                       new House("49Б", streets.Find(s => s.StreetName == "проспект Дзержинского")),
                                       new House("240А", streets.Find(s => s.StreetName == "улица Куйбышева")) };

        }*/

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
