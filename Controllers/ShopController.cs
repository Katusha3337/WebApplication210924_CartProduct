using Microsoft.AspNetCore.Mvc;
using WebApplication210924_CartProduct.Models;

namespace WebApplication210924_CartProduct.Controllers
{
    public class ShopController : Controller
    {
        private static List<Product> products = new List<Product>
    {
        new Product { Id = 1, Name = "Товар 1", Price = 100 },
        new Product { Id = 2, Name = "Товар 2", Price = 200 }
    };

        private static Cart cart = new Cart();

        public IActionResult Index()
        {
            return View(products);
        }

        [HttpPost]
        public IActionResult AddToCart(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                cart.AddItem(product);
            }
            return Json(new { itemCount = cart.Items.Sum(i => i.Quantity) });
        }

        public IActionResult Cart()
        {
            return View(cart);
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(string name, string phone, string address)
        {
            ViewBag.Name = name;
            ViewBag.Phone = phone;
            ViewBag.Address = address;
            ViewBag.Cart = cart;
            return View("OrderSummary");
        }

        public IActionResult GetCartItemCount()
        {
            int itemCount = cart.Items.Sum(i => i.Quantity);
            return Json(itemCount);
        }
    }
}
