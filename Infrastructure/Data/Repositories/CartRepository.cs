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
        private readonly IProductService _productService;
        //todo
        //change StoreContext to the interface
        public CartRepository(StoreContext storeContext, IProductService productService)
        {
            _storeContext = storeContext;
            _productService = productService;
        }
        //todo
        //check if Cart need to be an interface
        public async Task<Cart> AddProductToCartAsync(int customerId, int productId, int quantity)
        {
            var product = _storeContext.Products.FirstOrDefault(p => p.Id == productId);

            var cart = new Cart();

            if (product == null)
                return cart;

            if (_productService.IsThereEnoughStocks(product, quantity))
            {
                cart.CustomerId = customerId;
                cart.ProductId = productId;
                cart.Quantity = quantity;
                _storeContext.Carts.Add(cart);
                await _storeContext.SaveChangesAsync();
            }

            return cart;
        }

        public Task<Cart> GetCartContentByCustomerIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
