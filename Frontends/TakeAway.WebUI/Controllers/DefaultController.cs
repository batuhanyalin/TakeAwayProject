using Microsoft.AspNetCore.Mvc;
using TakeAway.WebUI.Services.CatalogServices.ProductServices;

namespace TakeAway.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IProductService _productService;

        public DefaultController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _productService.GetAllProductsAsync();
            return View(values);
        }
    }
}
