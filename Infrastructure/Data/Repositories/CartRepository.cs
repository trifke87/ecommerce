using Core.Common;
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
        public async Task<RValue<Cart>> AddProductToCartAsync(int customerId, int productId, int quantity)
        {
            var product = _storeContext.Products.FirstOrDefault(p => p.Id == productId);

            var cart = new Cart();

            if (product == null)
                return new RValue<Cart>(false, "Product doesn't exist");

            if (_productService.IsThereEnoughStocks(product, quantity))
            {
                cart.CustomerId = customerId;
                cart.ProductId = productId;
                cart.Quantity = quantity;
                _storeContext.Carts.Add(cart);
                await _storeContext.SaveChangesAsync();
            }
            else
                return new RValue<Cart>(false, "There is not enough quantity in stock");

            return new RValue<Cart>(true) { Value = cart };
        }

        public RValue<List<Cart>> GetCartContentByCustomerId(int customerId)
        {
            var carts = _storeContext.Carts.Where(c => c.CustomerId == customerId).ToList();

            if (carts == null || carts.Count == 0)
                return new RValue<List<Cart>>(false, "There is no result for the given custumerId");

            return new RValue<List<Cart>>(true) { Value = carts };
        }
    }
}
