using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly ISupplierProductService _supplierProductService;

        public ProductService(ISupplierProductService supplierProductService)
        {
            _supplierProductService = supplierProductService;
        }

        public bool IsThereEnoughStocks(Product product, int orderedQuantity)
        {
            int remainingQuantity = 0;

            var isThereEnoughLocalStocks = IsThereEnoughLocalStocksWithRemainingQuantity(product, orderedQuantity);

            if (isThereEnoughLocalStocks.Key)
                return true;
            else
                remainingQuantity = isThereEnoughLocalStocks.Value;

            if (IsThereEnoughSupplierStocks(product.Id, remainingQuantity))
                return true;

            return false;
        }

        private KeyValuePair<bool, int> IsThereEnoughLocalStocksWithRemainingQuantity(Product product, int orderedQuantity)
        {
            int remainingQuantity = orderedQuantity;

            if (product.Quantity >= orderedQuantity)
            {
                return new KeyValuePair<bool, int>(true, 0);
            }
            else
            {
                remainingQuantity = remainingQuantity - product.Quantity;
                return new KeyValuePair<bool, int>(false, remainingQuantity);
            }
        }

        private bool IsThereEnoughSupplierStocks(int productId, int remainingQuantity)
        {
            var supplierStock = _supplierProductService.GetSupplierProductInfo(productId);

            if (supplierStock == null)
                return false;

            if (supplierStock.Quantity >= remainingQuantity)
                return true;
            else if (supplierStock.Quantity - remainingQuantity >= 0)
                return true;

            return false;
        }
    }
}
