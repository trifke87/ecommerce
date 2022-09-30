using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductService
    {
        bool IsThereEnoughStocks(Product product, int orderedQuantity);
    }
}