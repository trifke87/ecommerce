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
        Task<RValue<string>> AddProductToCartAsync (int customerId, int productId, int quantity);
        RValue<List<Cart>> GetCartContentByCustomerId(int customerId);
    }
}
