using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
