using MenuApp.Data;
using MenuApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MenuApp.Services
{
	public class GeneralService : IGeneralService
	{
		private readonly DataContext _context;

		public GeneralService(DataContext context)
		{
			_context = context;
		}

		public async Task<List<Dish>> GetAllDishesAsync()
		{ 
			var result = await _context.Dishes.ToListAsync();
			return result;
		} 
	}
}
