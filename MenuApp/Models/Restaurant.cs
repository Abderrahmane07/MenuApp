namespace MenuApp.Models
{
	public class Restaurant
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string? Description { get; set; }
		public string? Address { get; set; }
		public string? PhoneNumber { get; set; }
		public string? Website { get; set; }
		public string? Email { get; set; }
		public int WorikngHoursId { get; set; }

	}
}
