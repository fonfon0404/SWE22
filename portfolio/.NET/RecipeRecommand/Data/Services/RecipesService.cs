using Microsoft.EntityFrameworkCore;
using RecipeRecommand.Data.Base;
using RecipeRecommand.Data.ViewModels;
using RecipeRecommand.Models;


namespace RecipeRecommand.Data.Services
{
    public class RecipesService : EntityBaseRepository<Recipe>, IRecipesService
    {
        private readonly ApplicationDbContext _context;
        public RecipesService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewRecipeAsync(NewRecipeVM data)
        {
            var newRecipe = new Recipe()
            {
                Name = data.Name,
                Description = data.Description,
                ImageURL = data.ImageURL
            };
            await _context.Recipes.AddAsync(newRecipe);
            await _context.SaveChangesAsync();

            //Add Recipe ingredients
            foreach (var ingredientId in data.IngredientIds)
            {
                var newIngredientRecipe = new Ingredient_Recipe()
                {
                    RecipeId = newRecipe.Id,
                    IngredientId = ingredientId
                };
                await _context.Ingredients_Recipes.AddAsync(newIngredientRecipe);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Recipe> GetRecipeByIdAsync(int id)
        {
            var recipeDetails = await _context.Recipes
                .Include(ir => ir.Ingredients_Recipes)
                .FirstOrDefaultAsync(n => n.Id == id);

            return recipeDetails;
        }

        public async Task<NewRecipeDropdownsVM> GetNewRecipeDropdownsValues()
        {
            var response = new NewRecipeDropdownsVM()
            {
                Ingredients = await _context.Ingredients.ToListAsync(),
            };

            return response;
        }

        public async Task UpdateRecipeAsync(NewRecipeVM data)
        {
            var dbRecipe = await _context.Recipes.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbRecipe != null)
            {
                dbRecipe.Name = data.Name;
                dbRecipe.Description = data.Description;
                dbRecipe.ImageURL = data.ImageURL;
                await _context.SaveChangesAsync();
            }

            //Remove existing
            var existingIngredientsDb = _context.Ingredients_Recipes.Where(n => n.RecipeId == data.Id).ToList();
            _context.Ingredients_Recipes.RemoveRange(existingIngredientsDb);
            await _context.SaveChangesAsync();

            //Adding
            foreach (var ingredientId in data.IngredientIds)
            {
                var newIngredientRecipe = new Ingredient_Recipe()
                {
                    RecipeId = data.Id,
                    IngredientId = ingredientId
                };
                await _context.Ingredients_Recipes.AddAsync(newIngredientRecipe);
            }
            await _context.SaveChangesAsync();
        }
    }
}
