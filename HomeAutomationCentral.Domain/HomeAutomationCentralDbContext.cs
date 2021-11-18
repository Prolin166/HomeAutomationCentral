using HomeAutomationCentral.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeAutomationCentral.Domain
{
    public class HomeAutomationCentralDbContext : DbContext
    {
        public DbSet<Area> Areas { get; set; }
        public DbSet<Device> Device { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseLazyLoadingProxies().UseSqlite("Data Source=sqlitedemo.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Device>()
                    .HasOne(a => a.Area)
                    .WithMany(d => d.Devices).HasForeignKey(d => d.AreaId).IsRequired(false); 

            base.OnModelCreating(modelBuilder); 
        }
    }
}
