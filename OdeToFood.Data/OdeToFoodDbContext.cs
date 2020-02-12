using System;
using System.Collections.Generic;
using System.Text;
using OdeToFood.Models;
using Microsoft.EntityFrameworkCore;

namespace OdeToFood.Data
{
    public class OdeToFoodDbContext: DbContext
    {
        public OdeToFoodDbContext(DbContextOptions<OdeToFoodDbContext> options) : base(options)
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
