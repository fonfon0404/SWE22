using RecipeRecommand.Models;

namespace RecipeRecommand.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                //Recipe
                if (!context.Recipes.Any())
                {
                    context.Recipes.AddRange(new List<Recipe>()
                    {
                        new Recipe()
                        {
                            Name = "Garlic Chicken",
                            Description = "Whole garlic cloves are mild when simmered with chicken in a simple white wine-mustard sauce in this garlic chicken recipe. Serve with smashed potatoes with buttermilk and sautéed green beans.",
                            ImageURL = "https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fstatic.onecms.io%2Fwp-content%2Fuploads%2Fsites%2F44%2F2019%2F08%2F26232612%2F3748651.jpg"
                        },
                        new Recipe()
                        {
                            Name = "Chicken & Zucchini Casserole",
                            Description = "This baked chicken and zucchini casserole is creamy, hearty and low-carb! The whole family will love this easy casserole, plus it's a great way to get the kids to eat their veggies (concealed in a delicious cheese sauce!).",
                            ImageURL = "https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fstatic.onecms.io%2Fwp-content%2Fuploads%2Fsites%2F44%2F2022%2F05%2F03%2Fchicken-and-zucchini-casserole-.jpg"
                        },
                        new Recipe()
                        {
                            Name = "One-Pan Chicken Parmesan Pasta",
                            Description = "This chicken Parmesan pasta uses the one-pot pasta method to cook your noodles, chicken and sauce all in one skillet for a fast and easy dinner with minimal cleanup. Finish the dish under the broiler to achieve a delicious melted cheese crust.",
                            ImageURL = "https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fstatic.onecms.io%2Fwp-content%2Fuploads%2Fsites%2F44%2F2020%2F03%2F24%2FOne-Pan-Chicken-Parmesan-Pasta.jpg"
                        }
                    });
                    context.SaveChanges();
                }
                //
                if (!context.Ingredients.Any())
                {
                    context.Ingredients.AddRange(new List<Ingredient>()
                    {
                        new Ingredient()
                        {
                            Name = "Chicken",
                            ImageURL = "https://st.depositphotos.com/2481033/2814/i/950/depositphotos_28146047-stock-photo-raw-chicken-legs-on-wood.jpg"
                        },
                        new Ingredient()
                        {
                            Name = "Red Bell Pepper",
                            ImageURL = "https://fsi.colostate.edu/wp-content/uploads/2019/07/pexels-artem-beliaikin-452773-1170x659.jpg"
                        },
                        new Ingredient()
                        {
                            Name = "Zucchini",
                            ImageURL = "https://www.thespruce.com/thmb/y8R759QcX93mTPPg2tSrSdk3rf0=/941x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/how-to-harvest-zucchini-2540052-hero-2d1787b1c5f449d0b4ceefc1f92d309f.jpg"
                        }
                    });
                    context.SaveChanges();
                }
                //Ingredient_Recipe
                if (!context.Ingredients_Recipes.Any())
                {
                    context.Ingredients_Recipes.AddRange(new List<Ingredient_Recipe>()
                    {
                        new Ingredient_Recipe()
                        {
                            RecipeId = 1,
                            IngredientId = 1
                        },
                        new Ingredient_Recipe()
                        {
                            RecipeId = 2,
                            IngredientId = 1
                        },
                        new Ingredient_Recipe()
                        {
                            RecipeId = 2,
                            IngredientId = 2
                        },
                        new Ingredient_Recipe()
                        {
                            RecipeId = 2,
                            IngredientId = 3
                        },
                        new Ingredient_Recipe()
                        {
                            RecipeId = 3,
                            IngredientId = 1
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
