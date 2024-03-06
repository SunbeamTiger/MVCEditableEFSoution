using DBProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MVCAppWithEF.ViewModels;


namespace MVCAppWithEF.Controllers
{
    public class CustController : Controller
    {
        private ICustomerRepository _Repo;   
        public CustController(ICustomerRepository customerRepository)
        {
            _Repo = customerRepository;
        }
        public ActionResult Index()
        {
           List<Customer> customers = _Repo.GetAllCustomers().ToList();  
           return View(customers); 
        }

        // GET: CustController/Details/5
        public ActionResult Details(int id)
        {
           Customer c = _Repo.GetCustomerById(id);  
           return View(c);
        }

        // GET: CustController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {
            EditCustomerViewModel ec = new EditCustomerViewModel();
            Customer c = _Repo.GetCustomerById(id);
            ec.LastName = c.LastName; 
            ec.FirstName = c.FirstName; 
            ec.Country= c.Country;
            ec.City = c.City;
            ec.Phone = c.Phone; 
            return View(ec);
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
         public IActionResult Edit(int Id, EditCustomerViewModel customer)
        {
          //if (ModelState.IsValid)
            Customer cust = _Repo.GetCustomerById(Id);
            cust.FirstName = customer.FirstName;    
            cust.LastName = customer.LastName;
            cust.Phone = customer.Phone;
            cust.City = customer.City;  
            cust.Country = customer.Country;
            cust = _Repo.Update(cust);
            try
            {
                return RedirectToAction("Index");
                //return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CustomersOrders()
        {
            List<CustomerOrder> co = _Repo.GetCustomersOrders(); 
            return View(co);    
        }
    }
}
