using DBProject.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection.Metadata;

namespace DBProject.Models
{
    public class CustomerRepository : ICustomerRepository
    {
        private GSContext _context;
        public CustomerRepository(GSContext context)
        {
            _context = context;
        }
        public Customer Update(Customer customer)
        {
            var c = _context.Customers.Attach(customer);
            c.State = EntityState.Modified;
            _context.SaveChanges();
            return customer;
        }
        public IEnumerable<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
            //IEnumerable<Customer> customers = _context.Customers;
            //IEnumerable<Customer> tempList = customers.Where(c=>c.Id==20).ToList<Customer>();
            //return tempList.ToList();
            //IQueryable<Customer> cust = _context.Customers.Where(c => c.Id == 25);

            //IQueryable<Customer> cust = _context.Customers.Where(c => c.City == "London").Take(2).OrderBy(c => c.LastName);

            //IQueryable<Customer> cust = _context.Customers.Select(* Where(c => c.City == "London");
            // System.Linq.IQueryable<string> name = _context.Customers.AsNoTracking().Select(c => c.FirstName));

            //return cust.ToList();   
        }

        public Customer GetCustomerById(int CustomerID)
        {
            return _context.Customers.Find(CustomerID);
        }
        public List<CustomerOrder> GetCustomersOrders()
        {

            var query = (from c in _context.Customers
                         join o in _context.Orders
                         on c.Id equals o.CustomerId
                         select new CustomerOrder
                         {
                             FirstName = c.FirstName,
                             LastName = c.LastName,
                             TotalAmount = o.TotalAmount,
                             City = c.City,
                             OrderDate = o.OrderDate

                         }).Take(5).ToList();
            return query.ToList();

        }

        public Customer Add(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;    
        }

        public bool Delete(int ID)
        {
            Customer c = GetCustomerById(ID);
            _context.Customers.Remove(c);
            _context.SaveChanges();
            return true;    
        }
    }
}
