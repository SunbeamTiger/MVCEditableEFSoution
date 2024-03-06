using DBProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace MVCAppWithEF.Controllers
{
    public class ListProductsController : Controller
    {
        private IProductRepository _productRepository;  
        public ListProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
    
        public IActionResult ListProducts()
        {
            var result = _productRepository.GetAllProductsandPrices();
            return View(result);
        }
    }
}
