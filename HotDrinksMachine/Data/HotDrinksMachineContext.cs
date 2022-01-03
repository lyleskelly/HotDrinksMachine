#nullable disable
using HotDrinksMachine.Models;
using Microsoft.EntityFrameworkCore;

namespace HotDrinksMachine.Data
{
    public class HotDrinksMachineContext : DbContext
    {
        public HotDrinksMachineContext(DbContextOptions<HotDrinksMachineContext> options)
            : base(options)
        {
        }

        public DbSet<HotDrinksMachine.Models.Drink> Drinks { get; set; }

        public DbSet<HotDrinksMachine.Models.Method> Methods { get; set; }

        public DbSet<HotDrinksMachine.Models.DrinkMethod> DrinkMethods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drink>().ToTable("Drink");
            modelBuilder.Entity<Method>().ToTable("Methods");
            modelBuilder.Entity<DrinkMethod>().ToTable("DrinkMethods");
        }
    }
}
