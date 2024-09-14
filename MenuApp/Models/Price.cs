namespace MenuApp.Models
{
	public class Price
	{
        public int Id { get; set; }
        public int DishId { get; set; }
        public string? PriceName { get; set; }
        public float PriceAmount { get; set; }
    }
}
