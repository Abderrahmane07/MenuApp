﻿using MenuApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MenuApp.Data
{
	public class DataContext : IdentityDbContext
	{
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

		public DbSet<Dish> Dishes {  get; set; } 
		public DbSet<Restaurant> Restaurants {  get; set; } 
		public DbSet<Category> Categories {  get; set; } 
		public DbSet<Price> Prices {  get; set; } 
    }
}
