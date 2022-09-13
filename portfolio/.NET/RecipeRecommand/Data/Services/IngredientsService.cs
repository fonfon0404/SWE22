using Microsoft.EntityFrameworkCore;
using RecipeRecommand.Data.Base;
using RecipeRecommand.Models;

namespace RecipeRecommand.Data.Services
{
        public class IngredientsService : EntityBaseRepository<Ingredient>, IIngredientsService
        {   
            public IngredientsService(ApplicationDbContext context) : base(context) { }
        }

}
