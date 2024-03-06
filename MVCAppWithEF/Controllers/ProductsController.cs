using DBProject.Context;
using DBProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace MVCAppWithEF.Controllers
{
    public class ProductsController : Controller
    {
        //private GSContext _gsContext;
        private ICustomerRepository _customerRepository;
        public ProductsController(ICustomerRepository context)
        {
            _customerRepository = context;
        }
        public IActionResult Featuredproducts()
        {
            //List<Product> products = _gsContext.Products.ToList();
            //return View(products);
            //var OneProduct = _gsContext.Products.Find(10);
            //var OneProduct = _gsContext.Products.Where(p=> p.UnitPrice>95).FirstOrDefault<Product>();    

            var oneCustomer = _customerRepository.GetCustomerById(32);
            return View(oneCustomer);
        }
    }
}
