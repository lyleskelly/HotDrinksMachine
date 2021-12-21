namespace HotDrinksMachine.Models
{
    public class DrinkIngredient
    {
        public int Id { get; set; }
        public Ingredient Ingredient { get; set; }
        public int DrinkId { get; set; }
        public int IngredientId { get; set; }
    }
}
