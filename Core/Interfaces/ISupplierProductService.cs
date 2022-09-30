using Core.Entities;

namespace Core.Interfaces
{
    public interface ISupplierProductService
    {
        Product GetSupplierProductInfo(int productId);
    }
}