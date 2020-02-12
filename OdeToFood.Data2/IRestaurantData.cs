using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetRestaurantById(int id);
        Restaurant Add(Restaurant newRestaurant);
        Restaurant Update(Restaurant updatedRestaurant);
        int Commit();

    }
    
    public class InMemoryRestaurantData : IRestaurantData
    {
        private List<Restaurant> _restaurants = new List<Restaurant>();

        public InMemoryRestaurantData()
        {
            _restaurants.Add(new Restaurant { Id = 1, CuisineType = CuisineType.Italian, Location = "Kyiv", Name = "Pizza Veterano" });
            _restaurants.Add(new Restaurant { Id = 2, CuisineType = CuisineType.Mexican, Location = "Odesa", Name = "Paper" });
            _restaurants.Add(new Restaurant { Id = 3, CuisineType = CuisineType.None, Location = "Sumy", Name = "Cozy evening" });
        }

        public Restaurant GetRestaurantById(int id)
        {
            return _restaurants.SingleOrDefault(r => r.Id == id);
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            _restaurants.Add(newRestaurant);
            newRestaurant.Id = _restaurants.Max(r => r.Id) + 1;

            return newRestaurant;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = GetRestaurantById(updatedRestaurant.Id);

            if(restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.CuisineType = updatedRestaurant.CuisineType;
            }

            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in _restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Id
                   select r;
                   
        }

        
    }
}
