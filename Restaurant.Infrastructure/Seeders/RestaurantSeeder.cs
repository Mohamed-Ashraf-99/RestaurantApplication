using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Seeders
{
    public class RestaurantSeeder(RestaurantDbContext context) : IRestaurantSeeder
    {
        public void Seed()
        {
            if (context.Database.CanConnect())
            {
                if (!context.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    context.Restaurants.AddRange(restaurants);
                    context.SaveChanges();
                }
            }
        }

        private IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>
            {
             new Restaurant
    {
        Name = "The Gourmet Kitchen",
        Description = "A fine dining experience with a blend of local and international cuisines.",
        Category = "Fine Dining",
        HasDelivery = true,
        ContactEmail = "info@gourmetkitchen.com",
        ContactNumber = "123-456-7890",
        Address = new Address
        {
            Street = "123 Fancy St",
            City = "Foodville",
            PostalCode = "90001"
        },
      
    },
             new Restaurant
    {
        Name = "Pizza Palace",
        Description = "Delicious handcrafted pizzas with a variety of toppings.",
        Category = "Casual Dining",
        HasDelivery = true,
        ContactEmail = "contact@pizzapalace.com",
        ContactNumber = "234-567-8901",
        Address = new Address
        {
            Street = "456 Pizza Blvd",
            City = "Cheesetown",
            PostalCode = "10001"
        },
    
    },
             new Restaurant
    {
        Name = "Sushi Central",
        Description = "Fresh and authentic sushi prepared by master chefs.",
        Category = "Japanese",
        HasDelivery = false,
        ContactEmail = "sushi@central.com",
        ContactNumber = "345-678-9012",
        Address = new Address
        {
            Street = "789 Sushi Way",
            City = "Fishcity",
            PostalCode = "75001"
        },
      
    },
             new Restaurant
    {
        Name = "Burger Hub",
        Description = "Juicy and flavorful burgers with a variety of sides.",
        Category = "Fast Food",
        HasDelivery = true,
        ContactEmail = "orders@burgerhub.com",
        ContactNumber = "456-789-0123",
        Address = new Address
        {
            Street = "101 Burger Lane",
            City = "Grilltown",
            PostalCode = "33001"
        },
 
    },
             new Restaurant
    {
        Name = "Taco Fiesta",
        Description = "A vibrant place offering a wide variety of tacos and Mexican dishes.",
        Category = "Mexican",
        HasDelivery = true,
        ContactEmail = "support@tacofiesta.com",
        ContactNumber = "567-890-1234",
        Address = new Address
        {
            Street = "202 Taco Ave",
            City = "Fiestaville",
            PostalCode = "87001"
        },

    }
            };

            return restaurants;
        }
    }
}
