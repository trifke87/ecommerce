using Core.Entities;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IProductService
    {
        KeyValuePair<bool, int> IsThereEnoughStocksWithRemainingLocalStocQuantity(Product product, int orderedQuantity);
    }
}