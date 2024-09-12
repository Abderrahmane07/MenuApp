using MenuApp.Models;

namespace MenuApp.Services
{
	public interface IGeneralService
	{
		Task<List<Dish>> GetAllDishesAsync();
	}
}
