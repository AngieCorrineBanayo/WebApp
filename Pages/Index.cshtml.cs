using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebApp.Pages
{
    public class Index : PageModel
    {
        public List<Product> Products { get; set; }

        [BindProperty]
        public SearchParameters SearchParams { get; set; }

        public void OnGet(string keyword = "", string searchBy = "", string sortBy = null, string sortAsc = "true", int pageSize = 5, int pageIndex = 1)
        {
            if (SearchParams == null)
            {
                SearchParams = new SearchParameters()
                {
                    SortBy = sortBy,
                    SortAsc = sortAsc == "true",
                    SearchBy = searchBy,
                    Keyword = keyword,
                    PageIndex = pageIndex,
                    PageSize = pageSize
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
                if (SearchParams.SearchBy.ToLower() == "id")
                {
                    Products = Products.Where(a => a.Id != null && a.Id.ToLower().Contains(SearchParams.Keyword.ToLower())).ToList();
                }
                else if (SearchParams.SearchBy.ToLower() == "name")
                {
                    Products = Products.Where(a => a.Name != null && a.Name.ToLower().Contains(SearchParams.Keyword.ToLower())).ToList();
                }
                else if (SearchParams.SearchBy.ToLower() == "category")
                {
                    Products = Products.Where(a => a.Category != null && a.Category.ToLower().Contains(SearchParams.Keyword.ToLower())).ToList();
                }
                else if (SearchParams.SearchBy.ToLower() == "price")
                {
                    Products = Products.Where(a => a.Price.ToString().Contains(SearchParams.Keyword)).ToList();
                }
            }
            else if ((string.IsNullOrEmpty(SearchParams.SearchBy) || SearchParams.SearchBy == "") && !string.IsNullOrEmpty(SearchParams.Keyword))
            {
                Products = Products.Where(a => a.Id != null && a.Id.ToLower().Contains(SearchParams.Keyword.ToLower())).ToList();
            }

            if (SearchParams.SortBy == null || SearchParams.SortAsc == null)
            {
                this.Products = Products;
                goto page;
            }

            if (SearchParams.SortBy.ToLower() == "id" && SearchParams.SortAsc == true)
            {
                this.Products = Products.OrderBy(a => a.Id).ToList();
            }
            else if (SearchParams.SortBy.ToLower() == "id" && SearchParams.SortAsc == false)
            {
                this.Products = Products.OrderByDescending(a => a.Id).ToList();
            }
            else if (SearchParams.SortBy.ToLower() == "name" && SearchParams.SortAsc == true)
            {
                this.Products = Products.OrderBy(a => a.Name).ToList();
            }
            else if (SearchParams.SortBy.ToLower() == "name" && SearchParams.SortAsc == false)
            {
                this.Products = Products.OrderByDescending(a => a.Name).ToList();
            }
            else if (SearchParams.SortBy.ToLower() == "price" && SearchParams.SortAsc == true)
            {
                this.Products = Products.OrderBy(a => a.Price).ToList();
            }
            else if (SearchParams.SortBy.ToLower() == "price" && SearchParams.SortAsc == false)
            {
                this.Products = Products.OrderByDescending(a => a.Price).ToList();
            }
            else if (SearchParams.SortBy.ToLower() == "category" && SearchParams.SortAsc == true)
            {
                this.Products = Products.OrderBy(a => a.Category).ToList();
            }
            else if (SearchParams.SortBy.ToLower() == "category" && SearchParams.SortAsc == false)
            {
                this.Products = Products.OrderByDescending(a => a.Category).ToList();
            }
            else
            {
                this.Products = Products;
            }

        page:
            int rem = this.Products.Count % pageSize;
            float pageCount = (this.Products.Count / pageSize) + (rem > 0 ? 1 : 0);
            int skip = (pageIndex <= pageCount ? pageSize * (pageIndex - 1) : pageSize * (Convert.ToInt32(pageCount - 1)));
            this.Products = this.Products.Skip(skip).Take(pageSize).ToList();
            SearchParams.SearchCount = this.Products.Count;
            SearchParams.PageCount = Convert.ToInt32(pageCount);
        }

        public class Product
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public string Category { get; set; }
        }

        public class SearchParameters
        {
            public string? SearchBy { get; set; }
            public string? Keyword { get; set; }
            public string? SortBy { get; set; }
            public bool? SortAsc { get; set; }
            public int? PageSize { get; set; }
            public int? PageIndex { get; set; }
            public int? PageCount { get; set;}
        }
    }

}







