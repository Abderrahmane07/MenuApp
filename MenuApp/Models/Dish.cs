namespace MenuApp.Models
{
	public class Dish
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public string? Ingredients { get; set; }

    }
}
