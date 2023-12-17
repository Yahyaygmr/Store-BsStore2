using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public ProductController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult Index()
        {
            var product = _serviceManager.ProductService.GetAllProducts(false);
            return View(product);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = _serviceManager.CategoryService.GetAllCategories(false);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] ProductDtoForInsertion p, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                //file operations start

                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);
                using (var stream = new FileStream(path,FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                p.ImageUrl = string.Concat("/images/",file.FileName);

                //file operations end

                _serviceManager.ProductService.CreateProduct(p);
                return RedirectToAction("Index");
            }
            return View();

        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.Categories = _serviceManager.CategoryService.GetAllCategories(false);
            var prd = _serviceManager.ProductService.GetOneProductForUpdate(id, false);
            return View(prd);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm] ProductDtoForUpdate productDto,IFormFile file)
        {
            if (ModelState.IsValid)
            {
                //file operations start

                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                productDto.ImageUrl = string.Concat("/images/", file.FileName);

                //file operations end

                _serviceManager.ProductService.UpdateOneProduct(productDto);
                return RedirectToAction("Index");
            }
            return View();

        }
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            _serviceManager.ProductService.DeleteOneProduct(id);
            return RedirectToAction("Index");
        }
    }
}
