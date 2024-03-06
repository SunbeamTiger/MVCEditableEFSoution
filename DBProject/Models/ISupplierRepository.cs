using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProject.Models
{
    public interface ISupplierRepository
    {
        IEnumerable<Supplier> GetAllSuppliers();
        Supplier GetSupplierById(int SupplierID);
    }
}
