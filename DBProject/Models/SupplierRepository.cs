using System.Linq;
using DBProject.Context;
namespace DBProject.Models
{
    public class SupplierRepository : ISupplierRepository
    {
        private GSContext _context;  
        public SupplierRepository(GSContext Context)
        {
            _context = Context;
        }
        public IEnumerable<Supplier> GetAllSuppliers()
        {
            List<Supplier> suppliers = _context.Suppliers.ToList();
            return suppliers;
        }
        public Supplier GetSupplierById(int SupplierID)
        {
            var oneSupplier = _context.Suppliers.Find(SupplierID);
            return oneSupplier;
        }
    }
}
