using Microsoft.EntityFrameworkCore;

namespace BatteryCondition.Models
{
    public class BatteryContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Street> Streets { get; set; }
        public DbSet<House> Houses { get; set; }

        public DbSet<BatteryBrand> Brands { get; set; }
        public DbSet<BatteryModel> BatteryModels { get; set; }
    }
}
