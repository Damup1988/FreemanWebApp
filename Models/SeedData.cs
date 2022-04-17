using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Models
{
    public class SeedData
    {
        public static void SeedDataBase(DataContext context)
        {
            context.Database.Migrate();
            if (!context.Products.Any() && !context.Suppliers.Any() && !context.Categories.Any())
            {
                Supplier s1 = new Supplier { City = "San Jose", Name = "Splash Dudes" };
                Supplier s2 = new Supplier { City = "Chicago", Name = "Soccer Town" };
                Supplier s3 = new Supplier { City = "NewYork", Name = "Chess Co" };

                Category c1 = new Category { Name = "Watersports" };
                Category c2 = new Category { Name = "Soccer" };
                Category c3 = new Category { Name = "Chess" };
                
                context.Products.AddRange(
                    new Product { Category = c1, Supplier = s1, Name = "Life jacket", Price = 48.95m},
                    new Product { Name = "Kayak", Price = 275, Category = c1, Supplier = s1},
                    new Product { Category = c2, Supplier = s2, Name = "Soccer ball", Price = 19.50m},
                    new Product { Category = c2, Supplier = s2, Name = "Cornet Flags", Price = 34.95m},
                    new Product { Name = "Stadium", Price = 79500, Category = c2, Supplier = s2},
                    new Product { Name = "Thinking Cap", Price = 16, Category = c3, Supplier = s3},
                    new Product { Name = "Unsteady Chair", Price = 29.95m, Category = c3, Supplier = s3},
                    new Product { Name = "Human Chess Board", Price = 75, Category = c3, Supplier = s3},
                    new Product { Name = "Bling-Bling King", Price = 1200, Category = c3, Supplier = s3});
                context.SaveChanges();
            }
        }
    }
}