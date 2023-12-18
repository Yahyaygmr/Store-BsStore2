using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IServiceManager _serviceManager;
        private readonly Cart _cart;

        public OrderController(IServiceManager serviceManager, Cart cart)
        {
            _serviceManager = serviceManager;
            _cart = cart;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Order());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Checkout([FromForm] Order order)
        {
            if (_cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty. Please add product to your cart.");
            }
            if (ModelState.IsValid)
            {
                order.Lines = _cart.Lines.ToArray();
                _serviceManager.OrderService.SaveOrder(order);
                _cart.Clear();
                return RedirectToPage("/Complate", new { OrderId = order.OrderId });
            }
            else
            {
                return View();
            }

        }
    }
}
