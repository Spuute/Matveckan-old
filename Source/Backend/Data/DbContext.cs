using Microsoft.EntityFrameworkCore;


namespace Backend.Models.Data
{
    public class FoodWeekContext : DbContext
    {
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<IngredientRecipe> RecipeIngredients { get; set; }
        public virtual DbSet<Instruction> Instructions { get; set; }
        public FoodWeekContext(DbContextOptions<FoodWeekContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IngredientRecipe>()
            .HasKey(ir => new {ir.RecipeId, ir.IngredientId});
            modelBuilder.Entity<IngredientRecipe>()
                .HasOne(ir => ir.Recipe)
                .WithMany(r => r.IngredientRecipes)
                .HasForeignKey(ir => ir.RecipeId)
                .OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<IngredientRecipe>()
                .HasOne(ir => ir.Ingredient)
                .WithMany(i => i.IngredientRecipes)
                .HasForeignKey(ir => ir.IngredientId);

            // modelBuilder.Entity<Instruction>()
            //     .HasIndex(i => i.StepNumber)
            //     .IsUnique();
        }
    }
}