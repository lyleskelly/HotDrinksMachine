using HotDrinksMachine.Models;

namespace HotDrinksMachine.Data
{
    public static class DbInitializer
    {
        public static void Initialize(HotDrinksMachineContext context)
        {
            //find drinks
            if (context.Drinks.Any() || context.Methods.Any() || context.DrinkMethods.Any())
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

            var methods = new Method[]
               {
                    new Method{Name="Boil some water"}, //1
                    new Method{Name="Steep the water in the tea"},  //2
                    new Method{Name="Pour in the cup"}, //3
                    new Method{Name="Add lemon"},   //4
                    new Method{Name="Brew the coffee grounds"}, //5
                    new Method{Name="Add Sugar"},   //6
                    new Method{Name="Add Milk"},    //7
                    new Method{Name="Add drinking chocolate powder to the water"}   //8
               };
            context.Methods.AddRange(methods);
            context.SaveChanges();

            var drinkMethods = new DrinkMethod[]
                {
                    new DrinkMethod{DrinkId=1, MethodId=1, Step=1},
                    new DrinkMethod{DrinkId=1, MethodId=2, Step=2},
                    new DrinkMethod{DrinkId=1, MethodId=3, Step=3},
                    new DrinkMethod{DrinkId=1, MethodId=4, Step=4},

                    new DrinkMethod{DrinkId=2, MethodId=1, Step=1},
                    new DrinkMethod{DrinkId=2, MethodId=5, Step=2},
                    new DrinkMethod{DrinkId=2, MethodId=3, Step=3},
                    new DrinkMethod{DrinkId=2, MethodId=6, Step=4},
                    new DrinkMethod{DrinkId=2, MethodId=7, Step=5},

                    new DrinkMethod{DrinkId=3, MethodId=1, Step=1},
                    new DrinkMethod{DrinkId=3, MethodId=8, Step=2},
                    new DrinkMethod{DrinkId=3, MethodId=3, Step=3}
                };
            context.DrinkMethods.AddRange(drinkMethods);
            context.SaveChanges();
        }
    }
}
