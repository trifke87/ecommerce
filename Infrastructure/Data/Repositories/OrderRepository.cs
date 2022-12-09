using Core.Business;
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
    public class OrderRepository : IOrderRepository
    {
        private readonly StoreContext _storeContext;

        public OrderRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        public async Task<RValue<Order>> CreateOrderAsync(int customerId, Address address, string phoneNumber)
        {
            var carts = _storeContext.Carts
                .Include(c => c.Product)
                .Where(c => c.CustomerId == customerId)
                .ToList();

            if (carts == null || carts.Count == 0)
                return new RValue<Order>(false, "There is no item in the cart for the given custumerId");

            var order = CreateOrderDetails(address, carts, phoneNumber);

            if (IsHappyHour(new TimeSpan(16, 0, 0), new TimeSpan(17, 0, 0)))
            {
                var discount = new Discount();

                discount.CalculateDiscount(order, phoneNumber);
            }

            await _storeContext.Orders.AddAsync(order);
            _storeContext.Carts.RemoveRange(carts);

            await _storeContext.SaveChangesAsync();

            return new RValue<Order>(true) { Value = order };
        }

        public bool IsHappyHour(TimeSpan timeStart, TimeSpan timeEnd)
        {
            if (DateTime.UtcNow.TimeOfDay >= timeStart && DateTime.UtcNow.TimeOfDay <= timeEnd)
                return true;
            return false;
        }

        private Order CreateOrderDetails(Address address, List<Cart> carts, string phoneNumber)
        {
            var order = new Order();
            order.Address = address;
            order.CustomerId = carts.FirstOrDefault().CustomerId;
            order.PhoneNumber = phoneNumber;
            carts.ForEach(item => { order.ItemOrdered.Add(new OrderItem { ProductId = item.Id, Quantity = item.Quantity, UnitPrice = item.Product.UnitPrice }); });
            order.TotalAmount = order.ItemOrdered.Sum(s => s.UnitPrice * s.Quantity);

            return order;
        }
    }
}
