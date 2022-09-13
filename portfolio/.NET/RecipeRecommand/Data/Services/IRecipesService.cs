using RecipeRecommand.Data.Base;
using RecipeRecommand.Data.ViewModels;
using RecipeRecommand.Models;

namespace RecipeRecommand.Data.Services
{
    public interface IRecipesService: IEntityBaseRepository<Recipe>
    {
        Task<Recipe> GetRecipeByIdAsync(int id);
        Task<NewRecipeDropdownsVM> GetNewRecipeDropdownsValues();
        Task AddNewRecipeAsync(NewRecipeVM data);
        Task UpdateRecipeAsync(NewRecipeVM data);
    }
}
