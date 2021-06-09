using Microsoft.EntityFrameworkCore;


namespace Backend.Models.Data
{
    public class FoodWeekContext : DbContext
    {
        public virtual DbSet<Recipe> Recipes { get; set; }
        //public virtual DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        public FoodWeekContext(DbContextOptions<FoodWeekContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<GameSession>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
        }
    }
}