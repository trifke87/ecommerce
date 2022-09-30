using Core.Common;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ICartRepository
    {
        //todo
        //check what it should return
        Task<RValue<Cart>> AddProductToCartAsync (int customerId, int productId, int quantity);
        Task<Cart> GetCartContentByCustomerIdAsync(int id);
    }
}
