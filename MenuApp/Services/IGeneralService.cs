using MenuApp.Models;

namespace MenuApp.Services
{
	public interface IGeneralService
	{
		Task<List<Dish>> GetAllDishesAsync();
		Task<Dish> GetDishByIdAsync(int id);
		Task AddDishAsync(Dish dish);
		Task UpdateDishAsync(Dish dish, int id);
		Task DeleteDishAsync(int id);
		Task<List<Restaurant>> GetAllRestaurantsAsync();
	}
}
