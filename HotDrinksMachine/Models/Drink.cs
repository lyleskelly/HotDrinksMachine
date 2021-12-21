using HotDrinksMachine.Enums;

namespace HotDrinksMachine.Models
{
    public class Drink
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Size Size { get; set; }

        public List<DrinkIngredient> DrinkIngredients { get; set; }
    }
}
