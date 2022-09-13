namespace RecipeRecommand.Models
{
    public class Ingredient_Recipe
    {
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }

        public virtual Recipe Recipe { get; set; }
        public virtual Ingredient Ingredient { get; set; }
    }
}
