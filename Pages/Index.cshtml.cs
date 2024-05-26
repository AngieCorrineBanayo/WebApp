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
                this.Products = products;
                return;
            }

            if (sortBy!.ToLower() == "name" && sortAsc!.ToLower() == "true")
            {
                this.Products = products.OrderBy(a => a.Name).ToList();
            }
            else if (sortBy!.ToLower() == "name" && sortAsc!.ToLower() == "false")
            {
                this.Products = products.OrderByDescending(a => a.Name).ToList();
            }
            else if (sortBy!.ToLower() == "price" && sortAsc!.ToLower() == "true")
            {
                this.Products = products.OrderBy(a => a.Price).ToList();
            }
            else if (sortBy!.ToLower() == "price" && sortAsc!.ToLower() == "false")
            {
                this.Products = products.OrderByDescending(a => a.Price).ToList();
            }
            else if (sortBy!.ToLower() == "category" && sortAsc!.ToLower() == "true")
            {
                this.Products = products.OrderBy(a => a.Category).ToList();
            }
            else if (sortBy!.ToLower() == "category" && sortAsc!.ToLower() == "false")
            {
                this.Products = products.OrderByDescending(a => a.Category).ToList();
            }
            else
            {
                this.Products = products;
            }
        }

        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public string Category { get; set; }
        }
    }
}