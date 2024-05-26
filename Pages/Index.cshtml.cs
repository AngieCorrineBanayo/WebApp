using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class Index : PageModel
    {
        private readonly ILogger<Index> _logger;

        public Index(ILogger<Index> logger)
        {
            _logger = logger;
        }

        public List<Product> Products { get; set; }

        public void OnGet(string? sortBy = null, string? sortAsc = "true")
        {
            List<Product> products = new List<Product>()
            {
                new Product {
                    Id = 1,
                    Name = "Laptop",
                    Price = 999.99m,
                    Category = "Electronics"
                },
                new Product {
                    Id = 2,
                    Name = "Smartphone",
                    Price = 699.99m,
                    Category = "Electronics"
                },
                new Product {
                    Id = 3,
                    Name = "Headphones",
                    Price = 199.99m,
                    Category = "Accessories"
                },
                new Product {
                    Id = 4,
                    Name = "Desk Chair",
                    Price = 149.99m,
                    Category = "Furniture"
                },
                new Product {
                    Id = 5,
                    Name = "Monitor",
                    Price = 249.99m,
                    Category = "Electronics"
                },
                new Product {
                    Id = 6,
                    Name = "Mouse",
                    Price = 49.99m,
                    Category = "Accessories"
                },
                new Product {
                    Id = 7,
                    Name = "Keyboard",
                    Price = 89.99m,
                    Category = "Accessories"
                },
                new Product {
                    Id = 8,
                    Name = "Printer",
                    Price = 129.99m,
                    Category = "Electronics"
                },
                new Product {
                    Id = 9,
                    Name = "Backpack",
                    Price = 59.99m,
                    Category = "Accessories"
                },
                new Product {
                    Id = 10,
                    Name = "Desk Lamp",
                    Price = 39.99m,
                    Category = "Furniture"
                },
                new Product {
                    Id = 11,
                    Name = "External Hard Drive",
                    Price = 79.99m,
                    Category = "Electronics"
                },
                new Product {
                    Id = 12,
                    Name = "Office Chair Mat",
                    Price = 29.99m,
                    Category = "Furniture"
                },
                new Product {
                    Id = 13,
                    Name = "Bluetooth Speaker",
                    Price = 99.99m,
                    Category = "Electronics"
                },
                new Product {
                    Id = 14,
                    Name = "Webcam",
                    Price = 49.99m,
                    Category = "Electronics"
                },
                new Product {
                    Id = 15,
                    Name = "Microphone",
                    Price = 79.99m,
                    Category = "Electronics"
                }
            };

            if (sortBy == null || sortAsc == null)
            {
                Products = products;
                return;
            }

            bool ascending = sortAsc.ToLower() == "true";

            Products = sortBy.ToLower() switch
            {
                "name" => ascending ? products.OrderBy(p => p.Name).ToList() : products.OrderByDescending(p => p.Name).ToList(),
                "price" => ascending ? products.OrderBy(p => p.Price).ToList() : products.OrderByDescending(p => p.Price).ToList(),
                "category" => ascending ? products.OrderBy(p => p.Category).ToList() : products.OrderByDescending(p => p.Category).ToList(),
                _ => products
            };
        }

        public class Product
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public decimal Price { get; set; }
            public string? Category { get; set; }
        }
    }
}
