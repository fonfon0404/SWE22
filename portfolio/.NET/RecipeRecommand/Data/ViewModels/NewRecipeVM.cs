using RecipeRecommand.Data;
using RecipeRecommand.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeRecommand.Models
{
    public class NewRecipeVM
    {
        public int Id { get; set; }

        [Display(Name = "Recipe name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Recipe description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "Recipe image URL")]
        [Required(ErrorMessage = "Recipe image URL is required")]
        public string ImageURL { get; set; }

        //Relationships
        [Display(Name = "Select ingredient(s)")]
        [Required(ErrorMessage = "Recipe ingredient(s) is required")]
        public List<int> IngredientIds { get; set; }

    }
}