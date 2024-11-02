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

		public async Task AddDishAsync(Dish dish)
		{
			using var context = await _contextFactory.CreateDbContextAsync();
			context.Dishes.Add(dish);	
			await context.SaveChangesAsync();
		}		

		public async Task UpdateDishAsync(Dish dish, int id)
		{
			using var context = await _contextFactory.CreateDbContextAsync();
			var dbDish = await context.Dishes.FindAsync(id);
			if (dbDish != null)
			{
				dbDish.Name = dish.Name; 
				//dbDish.Price = dish.Price; 

				await context.SaveChangesAsync();
			}
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

		public async Task<List<Restaurant>> GetAllRestaurantsAsync()
		{
			using var context = await _contextFactory.CreateDbContextAsync();
			var result = await context.Restaurants.ToListAsync();
			return result;
		}

		public async Task<List<Restaurant>> GetAllRestaurantesAsync()
		{
			using var context = await _contextFactory.CreateDbContextAsync();
			var result = await context.Restaurants.ToListAsync();
			return result;
		}

		public async Task<Restaurant> GetRestaurantByIdAsync(int id)
		{
			using var context = await _contextFactory.CreateDbContextAsync();
			var restaurant = await context.Restaurants.FindAsync(id);
			return restaurant;
		}

		public async Task AddRestaurantAsync(Restaurant restaurant)
		{
			using var context = await _contextFactory.CreateDbContextAsync();
			context.Restaurants.Add(restaurant);
			await context.SaveChangesAsync();
		}

		public async Task UpdateRestaurantAsync(Restaurant restaurant, int id)
		{
			using var context = await _contextFactory.CreateDbContextAsync();
			var dbRestaurant = await context.Restaurants.FindAsync(id);
			if (dbRestaurant != null)
			{
				dbRestaurant.Name = restaurant.Name;
				dbRestaurant.Description = restaurant.Description;
				dbRestaurant.Address = restaurant.Address;
				dbRestaurant.PhoneNumber = restaurant.PhoneNumber;
				dbRestaurant.Website = restaurant.Website;
				dbRestaurant.Email = restaurant.Email;

				await context.SaveChangesAsync();
			}
		}

		public async Task DeleteRestaurantAsync(int id)
		{
			using var context = await _contextFactory.CreateDbContextAsync();
			var restaurant = await context.Restaurants.FindAsync(id);
			if (restaurant != null)
			{
				context.Restaurants.Remove(restaurant);
				await context.SaveChangesAsync();
			}
		}


		public async Task<List<Category>> GetAllCategoriesByRestaurantIdAsync(int id)
		{
            using var context = await _contextFactory.CreateDbContextAsync();
            var categories = await context.Categories.Where(c => c.RestaurantId == id).ToListAsync();
			return categories;
        }

		public async Task<Category> GetCategoryByIdAsync(int id)
		{
			using var context = await _contextFactory.CreateDbContextAsync();
			var category = await context.Categories.FindAsync(id);
			return category;
		}

		public async Task AddCategoryAsync(Category category)
		{
			using var context = await _contextFactory.CreateDbContextAsync();
			context.Categories.Add(category);
			await context.SaveChangesAsync();
		}

		public async Task UpdateCategoryAsync(Category category, int id)
		{
			using var context = await _contextFactory.CreateDbContextAsync();
			var dbCategory = await context.Categories.FindAsync(id);
			if (dbCategory != null)
			{
				dbCategory.Name = category.Name;
				dbCategory.Description = category.Description;
				dbCategory.ParentCategoryId = category.ParentCategoryId;

				await context.SaveChangesAsync();
			}
		}

		public async Task DeleteCategoryAsync(int id)
		{
			using var context = await _contextFactory.CreateDbContextAsync();
			var category = await context.Categories.FindAsync(id);
			if (category != null)
			{
				context.Categories.Remove(category);
				await context.SaveChangesAsync();
			}
		}

	}
}
