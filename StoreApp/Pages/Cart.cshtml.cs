using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;

namespace StoreApp.Pages
{
    public class CartModel : PageModel
    {
        private readonly IServiceManager _serviceManager;
        public Cart Cart { get; set; }

        public CartModel(IServiceManager serviceManager,Cart cart)
        {
            _serviceManager = serviceManager;
            Cart = cart;
        }

       
        public string ReturnUrl { get; set; } = "/";
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int productId, string returnUrl)
        {
            Product? product = _serviceManager.ProductService.GetOneProduct(productId, false);
            if (product is not null)
            {
                Cart.AddItem(product, 1);
            }
            return Page();
        }

        public IActionResult OnPostRemove(int id, string returnUrl)
        {
            Cart.RemoveItem(Cart.Lines.First(cl => cl.Product.ProductId.Equals(id)).Product);
            return Page();
        }
    }
}
