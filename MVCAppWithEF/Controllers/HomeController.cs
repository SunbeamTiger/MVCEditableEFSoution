using DBProject.Context;
using DBProject.Models;
using Microsoft.AspNetCore.Mvc;
using MVCAppWithEF.Models;
using System.Diagnostics;

namespace MVCAppWithEF.Controllers
{
    public class HomeController : Controller
    {
        private ICustomerRepository _repo;

        //private GSContext _gsContext;
        public HomeController(ICustomerRepository context)
        {
            //_gsContext = context;
            _repo = context;
            //_gsContext.ChangeTracker.Clear();
        }

        public IActionResult Index()
        {
            List<Customer> cust = _repo.GetAllCustomers().ToList();
            return View(cust);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}