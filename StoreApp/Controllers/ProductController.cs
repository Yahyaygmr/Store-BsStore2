using Microsoft.AspNetCore.Mvc;
using Entities.Models;
using Repositories;
using Repositories.Contracts;
using Services.Contracts;
using Entities.RequestParameters;
using StoreApp.Models;

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

        public IActionResult ProductCard(ProductRepuestParameters p)
        {
            var products = _serviceManager.ProductService.GetAllProductsWithDetails(p);
            var pagination = new Pagination()
            {
                CurrentPage = p.PageNumber,
                ItemsPerPage = p.PageSize,
                TotalItems = _serviceManager.ProductService.GetAllProducts(false).Count()
            };
            return View(new ProductListViewModel()
            {
                Products = products,
                Pagination = pagination
            });
        }
    }
}