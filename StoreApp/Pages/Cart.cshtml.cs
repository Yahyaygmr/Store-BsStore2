using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;
using StoreApp.Infrasrtructe.Extensions;

namespace StoreApp.Pages
{
    public class CartModel : PageModel
    {
        private readonly IServiceManager _serviceManager;
        public Cart Cart { get; set; }

        public CartModel(IServiceManager serviceManager, Cart cartService)
        {
            _serviceManager = serviceManager;
            Cart = cartService;
        }


        public string ReturnUrl { get; set; } = "/";
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(int productId, string returnUrl)
        {
            Product? product = _serviceManager.ProductService.GetOneProduct(productId, false);
            if (product is not null)
            {
                //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(product, 1);
                //HttpContext.Session.SetJson<Cart>("cart", Cart);
            }
            return RedirectToPage(new { returnUrl = returnUrl});
        }

        public IActionResult OnPostRemove(int id, string returnUrl)
        {
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            Cart.RemoveItem(Cart.Lines.First(cl => cl.Product.ProductId.Equals(id)).Product);
            // HttpContext.Session.SetJson<Cart>("cart", Cart);
            return Page();
        }
    }
}
