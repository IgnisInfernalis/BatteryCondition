using Microsoft.EntityFrameworkCore;

namespace BatteryCondition.Models
{
    public class BatteryContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Street> Streets { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<AddressByDate> AddressByDates { get; set; }
        
        public DbSet<BatteryBrand> Brands { get; set; }
        public DbSet<BatteryModel> BatteryModels { get; set; }
        public DbSet<BatteryCondition> BatteryConditions { get; set; }
        public DbSet<CapacityByDate> CapacityByDates { get; set; }

        public BatteryContext(DbContextOptions<BatteryContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
