using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }
    }
}
