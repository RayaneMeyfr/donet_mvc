using Exercice4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exercice4.Controllers
{
    public class ProductController : Controller
    {
        public static string RandomString(string chars, int length)
        {
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Description = "Portable 15 pouces, 16GB RAM", Category = "Informatique" },
            new Product { Id = 2, Name = "Smartphone", Description = "Android 128GB, 6GB RAM", Category = "Téléphonie" },
            new Product { Id = 3, Name = "Chaise de bureau", Description = "Ergonomique, noire", Category = "Mobilier" },
            new Product { Id = 4, Name = "Cafetière", Description = "Machine à café filtre, 12 tasses", Category = "Cuisine" },
            new Product { Id = 5, Name = "Sac à dos", Description = "Résistant à l'eau, 20L", Category = "Accessoires" }
        };

        public IActionResult ListProducts()
        {
            return View(products);
        }

        public IActionResult Details(int id)
        {
            Product product = products.FirstOrDefault(c => c.Id == id);

            return View(product);
        }

        public IActionResult CreateRandom()
        {
            int newId = products.Any() ? products.Max(p => p.Id) + 1 : 1;

            Product product = new Product
            {
                Id = newId,
                Name = RandomString("ABCDEFGHIJKLMNOPQRSTUVWXYZ", 8),
                Description = "Description " + RandomString("abcdefghijklmnopqrstuvwxyz", 12),
                Category = RandomString("ABCDEFGHIJKLMNOPQRSTUVWXYZ", 6)
            };

            products.Add(product);

            return RedirectToAction("ListProducts");
        }

    }
}
