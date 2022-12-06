using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Decorators
{
    public class ThirtyPercentDecorator : IOrderItem
    {
        private readonly IOrderItem orderItem;

        public ThirtyPercentDecorator(IOrderItem orderItem)
        {
            this.orderItem = orderItem;
            Discount = 0.3m;
            DiscountAmount = orderItem.UnitPrice * Discount;
            UnitPrice = orderItem.UnitPrice - DiscountAmount;
        }

        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal DiscountAmount { get; set; }
    }
}
