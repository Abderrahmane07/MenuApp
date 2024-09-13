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

		public async Task AddDishAsync(Dish dish)
		{
			_context.Dishes.Add(dish);	
			await _context.SaveChangesAsync();
		}

		public async Task DeleteDishAsync(int id)
		{
			var dish = await _context.Dishes.FindAsync(id);
            if (dish != null)
			{
				_context.Dishes.Remove(dish);
				await _context.SaveChangesAsync();
			}
        }

		public async Task<List<Dish>> GetAllDishesAsync()
		{ 
			var result = await _context.Dishes.ToListAsync();
			return result;
		}

		public async Task<Dish> GetDishByIdAsync(int id)
		{
			var dish = await _context.Dishes.FindAsync(id);
			return dish;
		}

		public async Task UpdateDishAsync(Dish dish, int id)
		{
			var dbDish = await _context.Dishes.FindAsync(id);
			if (dbDish != null)
			{
				dbDish.Name = dish.Name; 
				dbDish.Price = dish.Price; 

				await _context.SaveChangesAsync();
			}
		}
	}
}
