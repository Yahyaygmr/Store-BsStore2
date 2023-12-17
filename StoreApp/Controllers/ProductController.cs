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
            // view k�sm�nda IQueryable lulland���m�z i�in tolist eklemedik sonuna (List<Product> olursa .Tolist() eklenmeli
            // Index �rnek olarak al�n�p kar��la�t�r�labilir. ��kt� ayn� fakat y�ntem farkl�)
            return View(model);
        }
    }
}