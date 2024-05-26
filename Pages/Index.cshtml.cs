using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class Indexname : PageModel
    {
        private readonly ILogger<Indexname> _logger;

        public Indexname(ILogger<Indexname> logger)
        {
            _logger = logger;
        }

        public List<Product> Products { get; set; }

        [BindProperty]
        public SearchParameters SearchParams { get; set; }

        public void OnGet(string keyword = "", string searchBy = "", string sortBy = null, string sortAsc = "true")
        {
            if (SearchParams == null)
            {
                SearchParams = new SearchParameters()
                {
                    SortBy = sortBy,
                    SortAsc = sortAsc == "true",
                    SearchBy = searchBy,
                    Keyword = keyword
                };
            }

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
            if (!string.IsNullOrEmpty(SearchParams.SearchBy) && !string.IsNullOrEmpty(SearchParams.Keyword))
            {
                switch (SearchParams.SearchBy.ToLower())
                {
                    case "id":
                        if (int.TryParse(SearchParams.Keyword, out int id))
                        {
                            products = products.Where(p => p.Id == id).ToList();
                        }
                        break;
                    case "name":
                        products = products.Where(p => p.Name != null && p.Name.ToLower().Contains(SearchParams.Keyword.ToLower())).ToList();
                        break;
                    case "category":
                        products = products.Where(p => p.Category != null && p.Category.ToLower().Contains(SearchParams.Keyword.ToLower())).ToList();
                        break;
                    case "price":
                        if (decimal.TryParse(SearchParams.Keyword, out decimal price))
                        {
                            products = products.Where(p => p.Price == price).ToList();
                        }
                        break;
                }
            }
            else if (string.IsNullOrEmpty(SearchParams.SearchBy) && !string.IsNullOrEmpty(SearchParams.Keyword))
            {
                products = products.Where(p => p.Name != null && p.Name.ToLower().Contains(SearchParams.Keyword.ToLower())).ToList();
            }

            if (!string.IsNullOrEmpty(SearchParams.SortBy))
            {
                switch (SearchParams.SortBy.ToLower())
                {
                    case "id":
                        products = SearchParams.SortAsc ? products.OrderBy(p => p.Id).ToList() : products.OrderByDescending(p => p.Id).ToList();
                        break;
                    case "name":
                        products = SearchParams.SortAsc ? products.OrderBy(p => p.Name).ToList() : products.OrderByDescending(p => p.Name).ToList();
                        break;
                    case "price":
                        products = SearchParams.SortAsc ? products.OrderBy(p => p.Price).ToList() : products.OrderByDescending(p => p.Price).ToList();
                        break;
                    case "category":
                        products = SearchParams.SortAsc ? products.OrderBy(p => p.Category).ToList() : products.OrderByDescending(p => p.Category).ToList();
                        break;
                }
            }

            Products = products;
        }

        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public string Category { get; set; }
        }

        public class SearchParameters
        {
            public string SearchBy { get; set; }
            public string Keyword { get; set; }
            public string SortBy { get; set; }
            public bool SortAsc { get; set; }
        }
    }
}









