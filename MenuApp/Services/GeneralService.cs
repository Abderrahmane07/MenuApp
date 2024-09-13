using MenuApp.Data;
using MenuApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MenuApp.Services
{
	public class GeneralService : IGeneralService
	{
		private readonly IDbContextFactory<DataContext> _contextFactory;

		public GeneralService(IDbContextFactory<DataContext> contextFactory)
		{
			_contextFactory = contextFactory;
		}

		public async Task AddDishAsync(Dish dish)
		{
			using var context = await _contextFactory.CreateDbContextAsync();
			context.Dishes.Add(dish);	
			await context.SaveChangesAsync();
		}

		public async Task DeleteDishAsync(int id)
		{
			using var context = await _contextFactory.CreateDbContextAsync();
			var dish = await context.Dishes.FindAsync(id);
            if (dish != null)
			{
				context.Dishes.Remove(dish);
				await context.SaveChangesAsync();
			}
        }

		public async Task<List<Dish>> GetAllDishesAsync()
		{
			using var context = await _contextFactory.CreateDbContextAsync();
			var result = await context.Dishes.ToListAsync();
			return result;
		}

		public async Task<Dish> GetDishByIdAsync(int id)
		{
			using var context = await _contextFactory.CreateDbContextAsync();
			var dish = await context.Dishes.FindAsync(id);
			return dish;
		}

		public async Task UpdateDishAsync(Dish dish, int id)
		{
			using var context = await _contextFactory.CreateDbContextAsync();
			var dbDish = await context.Dishes.FindAsync(id);
			if (dbDish != null)
			{
				dbDish.Name = dish.Name; 
				dbDish.Price = dish.Price; 

				await context.SaveChangesAsync();
			}
		}
	}
}
