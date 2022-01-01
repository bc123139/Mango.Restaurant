using Mango.Services.ProductAPI.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.Services.ProductAPI.Database
{
    public static class DatabaseContextSeed
    {
        public static async Task SeedDataAsync(DatabaseContext context)
        {
            await AddPreConfiguredProducts(context);
        }
        private static async Task AddPreConfiguredProducts(DatabaseContext context)
        {
            var products = context.Products.ToList();
            var newProducts = new List<Product>
            {
                new Product
                {
                Name = "Samosa",
                Price = 15,
                Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
                ImageUrl = "https://microservicesresources.blob.core.windows.net/mango/11.jfif",
                CategoryName = "Appetizer"
                },
                new Product
                {
                Name = "Paneer Tikka",
                Price = 13.99,
                Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
                ImageUrl = "https://microservicesresources.blob.core.windows.net/mango/12.jfif",
                CategoryName = "Appetizer"
                },
                new Product
                {
                Name = "Sweet Pie",
                Price = 10.99,
                Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
                ImageUrl = "https://microservicesresources.blob.core.windows.net/mango/13.jfif",
                CategoryName = "Dessert"
                },
                new Product
                {
                Name = "Pav Bhaji",
                Price = 15,
                Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
                ImageUrl = "https://microservicesresources.blob.core.windows.net/mango/14.jfif",
                CategoryName = "Entree"
            }

            };
            var result = newProducts.Where(gc => products.All(newGc => !string.Equals(newGc.Name, gc.Name, StringComparison.CurrentCultureIgnoreCase)));
            await context.Products.AddRangeAsync(result);
            await context.SaveChangesAsync();
        }
    }
}
