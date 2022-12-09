using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Decorators
{
    class TwentyPercentDecorator : IOrder
    {
        private readonly IOrder order;

        public TwentyPercentDecorator(IOrder order)
        {
            this.order = order;
            Discount = 0.2m;
            order.ItemOrdered.ForEach((item) =>
            {
                item.DiscountAmount = item.UnitPrice * Discount;
                item.UnitPrice = item.UnitPrice - item.DiscountAmount;
            });
            TotalAmount = order.ItemOrdered.Sum(s => s.UnitPrice * s.Quantity);
            ItemOrdered = order.ItemOrdered;
        }

        public List<OrderItem> ItemOrdered { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
