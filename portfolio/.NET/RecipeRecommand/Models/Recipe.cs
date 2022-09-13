using RecipeRecommand.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace RecipeRecommand.Models
{
    public class Recipe : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }

        // Relationships
        public virtual ICollection<Ingredient_Recipe> Ingredients_Recipes { get; set; }
        public virtual ICollection<Ingredient> Ingredient { get; set; }
    }
}
