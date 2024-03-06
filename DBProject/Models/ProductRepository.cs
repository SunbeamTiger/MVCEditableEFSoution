using DBProject.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DBProject.Models
{
    public class ProductRepository : IProductRepository
    {
        private GSContext _context;
        public ProductRepository(GSContext GSCon) 
        {
            _context = GSCon;
        }  
        public IEnumerable<Product> GetAllProductsandPrices()
        {
            var myProducts = _context.Products.AsQueryable().Select(p => new Product
            {
                Id = p.Id,
                ProductName = p.ProductName,
                UnitPrice = p.UnitPrice,
                Package = p.Package
            }
            ).Where(p => p.Id > 70 && 
                    p.UnitPrice > 21 && 
                    p.Package.Contains("pkgs")).ToList();

            return myProducts;
     
        }

        public Supplier GetProductById(int ProductID)
        {
            throw new NotImplementedException();
        }
    }
}
