
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Contants;
using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Seeders;

internal class RestaurantSeeder(RestaurantsDbContext context) : IRestaurantSeeder
{
    public async Task Seed()
    {
        if (context.Database.GetPendingMigrations().Any())
        {
            await context.Database.MigrateAsync();
        }

        if (await context.Database.CanConnectAsync())
        {
            if (!context.Restaurants.Any())
            {
                var restaurants = GetRestaurants();
                context.Restaurants.AddRange(restaurants);
                await context.SaveChangesAsync();
            }

            if (!context.Roles.Any())
            {
                var roles = GetRoles();
                context.Roles.AddRange(roles);
                await context.SaveChangesAsync();
            }
        }
    }

    private IEnumerable<IdentityRole> GetRoles()
    {
        List<IdentityRole> roles = [
            new(UserRoles.User)
            {
                NormalizedName = UserRoles.User.ToUpper()
            },
            new(UserRoles.Owner)
            {
                NormalizedName = UserRoles.Owner.ToUpper()
            },
            new(UserRoles.Admin)
            {
                NormalizedName = UserRoles.Admin.ToUpper()
            }
        ];
        return roles;
    }

    private IEnumerable<Restaurant> GetRestaurants()
    {
        List<Restaurant> restaurants = [
            new()
            {
                Name = "KFC",
                Category = "Fast Food",
                Description = "Fried chicken and fast food, is an American fast food restaurant chain headquartered in Louisville, Kentucky, that specializes in fried chicken.",
                ContactEmail = "contact@kfc.com",
                HasDelivery = true,
                Dishes = [
                    new()
                    {
                        Name = "Chicken Nuggets",
                        Description = "Chicken nuggets are pieces of chicken that have been breaded or battered, then deep fried or baked.",
                        Price = 5.99M
                    },
                    new()
                    {
                        Name = "Chicken Sandwich",
                        Description = "A chicken sandwich is a sandwich that typically consists of boneless, skinless chicken breast, or fried chicken cutlet.",
                        Price = 6.99M
                    }
                ],
                Address = new()
                {
                    City = "New York",
                    Street = "5th Avenue",
                    PostalCode = "10001"
                }
            }
        ];
        return restaurants;
    }
}