using Microsoft.AspNetCore.Mvc;
using DBProject.Models;
namespace MVCAppWithEF.Controllers
{
    public class SupplierController : Controller
    {
        private ISupplierRepository _SupplierRepo;
        public SupplierController(ISupplierRepository repo)
        {
            _SupplierRepo = repo;   
        }
        public IActionResult Suppliers()
        {
            List<Supplier> suppliers = (List<Supplier>)_SupplierRepo.GetAllSuppliers();  
            return View(suppliers);
        }
   
    }
}
