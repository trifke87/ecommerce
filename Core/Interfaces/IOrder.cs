using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IOrder
    {
        List<OrderItem> ItemOrdered { get; set; }
        decimal Discount { get; set; }
        decimal TotalAmount { get; set; }
    }
}
