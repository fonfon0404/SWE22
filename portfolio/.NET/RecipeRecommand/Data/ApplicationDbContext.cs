using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RecipeRecommand.Models;

namespace RecipeRecommand.Data
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Ingredient_Recipe>().HasKey(ir => new
            {
                ir.RecipeId,
                ir.IngredientId
            });

            modelBuilder.Entity<Ingredient_Recipe>().HasOne(r => r.Recipe).WithMany(ir => ir.Ingredients_Recipes).
                HasForeignKey(r => r.RecipeId);
            modelBuilder.Entity<Ingredient_Recipe>().HasOne(I => I.Ingredient).WithMany(ir => ir.Ingredients_Recipes).
                HasForeignKey(i => i.IngredientId);*/



            // update core 6.0 Mitigations from MicroSoft
            // https://docs.microsoft.com/en-us/ef/core/what-is-new/ef-core-6.0/breaking-changes#many-to-many
            // still incomplete
            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.HasMany(i => i.Ingredient)
                    .WithMany(r => r.Recipe)
                    .UsingEntity<Ingredient_Recipe>(
                        l => l.HasOne<Ingredient>(e => e.Ingredient).WithMany(e => e.Ingredients_Recipes).HasForeignKey(e => e.IngredientId),
                        t => t.HasOne<Recipe>(e => e.Recipe).WithMany(e => e.Ingredients_Recipes).HasForeignKey(e => e.RecipeId),
                        j =>
                        {
                            j.HasKey("RecipeId", "IngredientId");
                            j.ToTable("Ingredients_Recipes");
                        });
            });
            
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Ingredient_Recipe> Ingredients_Recipes { get; set; }
    }
}
