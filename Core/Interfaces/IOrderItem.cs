using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IOrderItem
    {
        decimal UnitPrice { get; set; }
        decimal Discount { get; set; }
        decimal DiscountAmount { get; set; }
    }
}
