using Core.Common;

namespace Core.Interfaces
{
    public interface ICartValidator
    {
        RValue<bool> AddToShopingCartValidate(int customerId, int productId, int quantity);

        RValue<bool> GetCartContentValidate(int customerId);
    }
}