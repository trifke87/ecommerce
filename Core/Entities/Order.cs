using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Order : IOrder
    {
        public Order()
        {
            ItemOrdered = new List<OrderItem>();
        }
        public int Id { get; set; }
        public List<OrderItem> ItemOrdered { get; set; }
        public int CustomerId { get; set; }
        public Address Address { get; set; }
        public string PhoneNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }
    }
}
