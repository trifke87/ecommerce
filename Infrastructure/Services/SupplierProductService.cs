using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class SupplierProductService : ISupplierProductService
    {
        public Product GetSupplierProductInfo(int productId)
        {
            var products = new List<Product>();
            products.Add(new Product { Id = 1, Name = "Chair", UnitPrice = 12, Quantity = 2});
            products.Add(new Product { Id = 2, Name = "Table", UnitPrice = 78.55m, Quantity = 20 });
            products.Add(new Product { Id = 3, Name = "Lamp", UnitPrice = 8.22m, Quantity = 0 });
            products.Add(new Product { Id = 4, Name = "Couch", UnitPrice = 355.55m, Quantity = 1 });

            return products.FirstOrDefault(p => p.Id == productId);
        }
    }
}
