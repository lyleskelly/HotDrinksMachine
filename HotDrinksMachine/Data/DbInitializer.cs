using HotDrinksMachine.Models;

namespace HotDrinksMachine.Data
{
    public static class DbInitializer
    {
        public static void Initialize(HotDrinksMachineContext context)
        {
            //find drinks
            if (context.Drinks.Any() || context.Ingredients.Any() || context.DrinkIngredients.Any())
            {
                return;
            }

            var drinks = new Drink[]
                {
                    new Drink{Name="Lemon Tea", Description="Tea with a slice of lemon", Size=Enums.Size.Small},
                    new Drink{Name="Coffee", Description="Just coffee", Size=Enums.Size.Small},
                    new Drink{Name="Chocolate", Description="Hot chocolate", Size=Enums.Size.Small}
                };
            context.Drinks.AddRange(drinks);
            context.SaveChanges();

            var ingredients = new Ingredient[]
               {
                    new Ingredient{Name="Water"},
                    new Ingredient{Name="Tea"},
                    new Ingredient{Name="Lemon"},
                    new Ingredient{Name="Coffee"},
                    new Ingredient{Name="Sugar"},
                    new Ingredient{Name="Milk"},
                    new Ingredient{Name="Drinking chocolate"}
               };
            context.Ingredients.AddRange(ingredients);
            context.SaveChanges();

            var drinkIngredients = new DrinkIngredient[]
                {
                    new DrinkIngredient{DrinkId=1, IngredientId=1},
                    new DrinkIngredient{DrinkId=1, IngredientId=2},
                    new DrinkIngredient{DrinkId=1, IngredientId=3},

                    new DrinkIngredient{DrinkId=2, IngredientId=1},
                    new DrinkIngredient{DrinkId=2, IngredientId=4},
                    new DrinkIngredient{DrinkId=2, IngredientId=5},
                    new DrinkIngredient{DrinkId=2, IngredientId=6},

                    new DrinkIngredient{DrinkId=3, IngredientId=1},
                    new DrinkIngredient{DrinkId=3, IngredientId=7},
                };
            context.DrinkIngredients.AddRange(drinkIngredients);
            context.SaveChanges();
        }
    }
}
