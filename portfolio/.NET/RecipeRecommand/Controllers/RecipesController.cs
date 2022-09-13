using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeRecommand.Data;
using RecipeRecommand.Data.Services;
using RecipeRecommand.Data.Base;
using RecipeRecommand.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RecipeRecommand.Controllers
{
    public class RecipesController : Controller
    {
        private readonly IRecipesService _service;

        public RecipesController(IRecipesService service)
        {
            _service = service;
        }

        // Index show all recipes
        public async Task<IActionResult> Index()
        {
            var allRecipes = await _service.GetAllAsync(n => n.Ingredients_Recipes);
            return View(allRecipes);
        }

        // Search bar function
        public async Task<IActionResult> Filter(string searchString)
        {
            var allRecipes = await _service.GetAllAsync(n => n.Ingredients_Recipes);

            if (!string.IsNullOrEmpty(searchString))
            {
                // Exact search
                var filteredResult = allRecipes.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();
                // Keyword search but not yet implemented
                //var filteredResult = _service.Ingredients.Include(n => n.Name);
                return View("Index", filteredResult);
            }

            return View("Index", allRecipes);
        }

        // Get detail of recipe
        public async Task<IActionResult> Details(int id)
        {
            var recipeDetail = await _service.GetRecipeByIdAsync(id);
            return View(recipeDetail);
        }

        // Create recipe by user; not yet implemented
        //public async Task<IActionResult> Create()

        // Edit recipe by user
        public async Task<IActionResult> Edit(int id)
        {
            var recipeDetails = await _service.GetRecipeByIdAsync(id);
            if (recipeDetails == null) return View("NotFound");

            var response = new NewRecipeVM()
            {
                Id = recipeDetails.Id,
                Name = recipeDetails.Name,
                Description = recipeDetails.Description,
                ImageURL = recipeDetails.ImageURL,
                IngredientIds = recipeDetails.Ingredients_Recipes.Select(n => n.IngredientId).ToList(),
            };

            var recipeDropdownsData = await _service.GetNewRecipeDropdownsValues();
            ViewBag.Ingredients = new SelectList(recipeDropdownsData.Ingredients, "Id", "Name");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewRecipeVM recipe)
        {
            if (id != recipe.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var recipeDropdownsData = await _service.GetNewRecipeDropdownsValues();

                ViewBag.Actors = new SelectList(recipeDropdownsData.Ingredients, "Id", "Name");

                return View(recipe);
            }

            await _service.UpdateRecipeAsync(recipe);
            return RedirectToAction(nameof(Index));
        }
    }
}
