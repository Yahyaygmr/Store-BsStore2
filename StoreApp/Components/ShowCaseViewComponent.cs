using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Components
{
    public class ShowCaseViewComponent : ViewComponent
    {
        private readonly IServiceManager _serviceManager;

        public ShowCaseViewComponent(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        public IViewComponentResult Invoke()
        {
            var products = _serviceManager.ProductService.GetShowCaseProducts(false);

            return View(products);
        }
    }
}
