using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Decorators
{
    public class ThirtyPercentDecorator : IOrder
    {
        private readonly IOrder order;

        public ThirtyPercentDecorator(IOrder order)
        {
            this.order = order;
            Discount = 0.3m;
            order.ItemOrdered.ForEach((item) => 
            { 
                item.DiscountAmount = item.UnitPrice * Discount;
                item.UnitPrice = item.UnitPrice - item.DiscountAmount;
            });
            TotalAmount = order.ItemOrdered.Sum(s => s.UnitPrice * s.Quantity);
            ItemOrdered = order.ItemOrdered;
        }

        public List<OrderItem> ItemOrdered { get; set; } = new List<OrderItem>();
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
