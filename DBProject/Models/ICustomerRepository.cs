using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProject.Models
{
    public interface ICustomerRepository
    {
        Customer Update(Customer customer);
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(int CustomerID);
        public List<CustomerOrder> GetCustomersOrders();
    }
}
