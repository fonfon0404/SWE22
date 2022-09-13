using RecipeRecommand.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeRecommand.Data.ViewModels
{
    public class NewRecipeDropdownsVM
    {
        public NewRecipeDropdownsVM()
        {
            Ingredients = new List<Ingredient>();
        }
        public List<Ingredient> Ingredients { get; set; }
    }
}
