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

        public DbSet<HotDrinksMachine.Models.Ingredient> Ingredients { get; set; }

        public DbSet<HotDrinksMachine.Models.DrinkIngredient> DrinkIngredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drink>().ToTable("Drink");
            modelBuilder.Entity<Ingredient>().ToTable("Ingredient");
            modelBuilder.Entity<DrinkIngredient>().ToTable("DrinkIngredient");
        }
    }
}
