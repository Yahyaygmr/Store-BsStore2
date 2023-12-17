using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Components
{
    public class CategoryListViewComponent : ViewComponent
    {
        private readonly IServiceManager _serviceManager;

        public CategoryListViewComponent(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        public IViewComponentResult Invoke()
        {
            var categories = _serviceManager.CategoryService.GetAllCategories(false);
            return View(categories);
        }
    }
}
