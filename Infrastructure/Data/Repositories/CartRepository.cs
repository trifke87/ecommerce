using Core.Common;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
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
        public async Task<RValue<string>> AddProductToCartAsync(int customerId, int productId, int quantity)
        {
            string response = String.Empty;

            var product = _storeContext.Products.FirstOrDefault(p => p.Id == productId);

            if (product == null)
                return new RValue<string>(false, "Product doesn't exist");

            var IsThereEnoughStocksWithRemainingQuantity = _productService.IsThereEnoughStocksWithRemainingLocalStocQuantity(product, quantity);

            if (IsThereEnoughStocksWithRemainingQuantity.Key)
            {
                response = CartHandler(customerId, product, quantity).Value;

                ProductLocalQuantityHandler(product, IsThereEnoughStocksWithRemainingQuantity.Value);

                await _storeContext.SaveChangesAsync();
            }
            else
                return new RValue<string>(false, "There is not enough quantity in stock");

            return new RValue<string>(true) { Value = response };
        }

        public RValue<List<Cart>> GetCartContentByCustomerId(int customerId)
        {
            var carts = _storeContext.Carts
                .Include(c=>c.Product)
                .Where(c => c.CustomerId == customerId)
                .ToList();

            if (carts == null || carts.Count == 0)
                return new RValue<List<Cart>>(false, "There is no result for the given custumerId");

            return new RValue<List<Cart>>(true) { Value = carts };
        }

        private RValue<string> CartHandler(int customerId, Product product, int quantity)
        {
            var cartExist = _storeContext.Carts.FirstOrDefault(c => c.CustomerId == customerId && c.Product.Id == product.Id);

            if (cartExist == null)
            {
                var response = AddNewItemToCart(customerId, product, quantity);
                return new RValue<string>(true) { Value = response.Value };
            }
            else
            {
                var response = UpdateItemFromCart(cartExist, quantity);
                return new RValue<string>(true) { Value = response.Value };
            }
        }

        private RValue<string> AddNewItemToCart(int customerId, Product product, int quantity)
        {
            var cart = new Cart();
            cart.CustomerId = customerId;
            cart.Product = product;
            cart.Quantity = quantity;
            _storeContext.Carts.Add(cart);

            return new RValue<string>(true) { Value = "Item added to the cart" };
        }

        private RValue<string> UpdateItemFromCart(Cart cart, int quantity)
        {
            cart.Quantity = cart.Quantity + quantity;
            _storeContext.Carts.Update(cart);

            return new RValue<string>(true) { Value = "Cart item updated" };
        }

        private void ProductLocalQuantityHandler(Product product, int remaingQuantity)
        {
            product.Quantity = remaingQuantity;
            _storeContext.Products.Update(product);
        }
    }
}
