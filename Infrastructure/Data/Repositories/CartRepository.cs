using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly StoreContext _storeContext;

        //todo
        //change StoreContext to the interface
        public CartRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        //todo
        //check if Cart need to be an interface
        public Task<Cart> AddProductToCartAsync(int customerId, int productId, int quantity)
        {
            var product = _storeContext.Products.FirstOrDefault(p => p.Id == productId);
        }

        public Task<Cart> GetCartContentByCustomerIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
