using Core.Common;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Validations
{
    public class CartValidator : ICartValidator
    {
        public RValue<bool> AddToShopingCartValidate(int customerId, int productId, int quantity)
        {
            if (customerId <= 0)
                return new RValue<bool>(false, "customerId cannot be less than 1");

            if (productId <= 0)
                return new RValue<bool>(false, "productId cannot be less than 1");

            if (quantity <= 0)
                return new RValue<bool>(false, "quantity cannot be less than 1");

            return new RValue<bool>(true);
        }

        public RValue<bool> GetCartContentValidate(int customerId)
        {
            if (customerId <= 0)
                return new RValue<bool>(false, "customerId cannot be less than 1");

            return new RValue<bool>(true);
        }
    }
}
