namespace HotDrinksMachine.Models
{
    public class DrinkMethod
    {
        public int Id { get; set; }
        public Method Method { get; set; }
        public int DrinkId { get; set; }
        public int MethodId { get; set; }

        public int Step { get; set; }
    }
}
