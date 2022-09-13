using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeRecommand.Data;
using RecipeRecommand.Data.Services;

namespace RecipeRecommand.Controllers
{
    public class IngredientsController : Controller
    {
        private readonly IIngredientsService _service;

        public IngredientsController(IIngredientsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allIngredients = await _service.GetAllAsync(n => n.Ingredients_Recipes);
            return View(allIngredients);
        }
    }
}
