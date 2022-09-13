using RecipeRecommand.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace RecipeRecommand.Models
{
    public class Ingredient : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Image URL")]
        public string ImageURL { get; set; }

        // Relationships
        public virtual ICollection<Ingredient_Recipe> Ingredients_Recipes { get; set; }
        public virtual ICollection<Recipe> Recipe { get; set; }
    }
}
