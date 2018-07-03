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
        public DbSet<BatteryPack> BatteryPacks { get; set; }
        public DbSet<BatteryConditionBatteryPack> BatteryConditionBatteryPacks { get; set; }

        public BatteryContext(DbContextOptions<BatteryContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BatteryConditionBatteryPack>()
                .HasKey(bcbp => new { bcbp.BatteryConditionId, bcbp.BatteryPackId });
            modelBuilder.Entity<BatteryConditionBatteryPack>()
                .HasOne(bcbp => bcbp.BatteryCondition)
                .WithMany(bc => bc.BatteryConditionBatteryPack)
                .HasForeignKey(bcbp => bcbp.BatteryConditionId);
            modelBuilder.Entity<BatteryConditionBatteryPack>()
                .HasOne(bcbp => bcbp.BatteryPack)
                .WithMany(bp => bp.BatteryConditionBatteryPacks)
                .HasForeignKey(bcbp => bcbp.BatteryPackId);
        }
    }
}
