using Microsoft.AspNetCore.Mvc;
using Entities.Models;
using Repositories;
using Repositories.Contracts;
using Services.Contracts;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public ProductController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult Index()
        {
            var model = _serviceManager.ProductService.GetAllProducts(false).ToList();
            return View(model);
        }
        public IActionResult Get([FromRoute(Name = "id")] int id)
        {
            var prd = _serviceManager.ProductService.GetOneProduct(id, false);

            return View(prd);
        }

        public IActionResult ProductCard()
        {
            var model = _serviceManager.ProductService.GetAllProducts(false);
            // view kýsmýnda IQueryable lullandýðýmýz için tolist eklemedik sonuna (List<Product> olursa .Tolist() eklenmeli
            // Index örnek olarak alýnýp karþýlaþtýrýlabilir. Çýktý ayný fakat yöntem farklý)
            return View(model);
        }
    }
}