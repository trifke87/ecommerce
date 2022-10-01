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

        public KeyValuePair<bool,int> IsThereEnoughStocksWithRemainingLocalStocQuantity(Product product, int orderedQuantity)
        {
            int remainingToOrderQuantity = 0;

            var IsThereEnoughLocalStocksWithRemainingToOrder = this.IsThereEnoughLocalStocksWithRemainingToOrder(product, orderedQuantity);

            if (IsThereEnoughLocalStocksWithRemainingToOrder.Key)
                return new KeyValuePair<bool, int>(true, product.Quantity - orderedQuantity);
            else
                remainingToOrderQuantity = IsThereEnoughLocalStocksWithRemainingToOrder.Value;

            if (IsThereEnoughSupplierStocks(product.Id, remainingToOrderQuantity))
                return new KeyValuePair<bool, int>(true, 0);

            return new KeyValuePair<bool, int>(false, product.Quantity);
        }

        private KeyValuePair<bool, int> IsThereEnoughLocalStocksWithRemainingToOrder(Product product, int orderedQuantity)
        {
            int remainingQuantityToOrder = orderedQuantity;

            if (product.Quantity >= orderedQuantity)
            {
                return new KeyValuePair<bool, int>(true, 0);
            }
            else
            {
                remainingQuantityToOrder = remainingQuantityToOrder - product.Quantity;
                return new KeyValuePair<bool, int>(false, remainingQuantityToOrder);
            }
        }

        private bool IsThereEnoughSupplierStocks(int productId, int remainingToOrderQuantity)
        {
            var supplierStock = _supplierProductService.GetSupplierProductInfo(productId);

            if (supplierStock == null)
                return false;

            if (supplierStock.Quantity >= remainingToOrderQuantity)
                return true;
            else if (supplierStock.Quantity - remainingToOrderQuantity >= 0)
                return true;

            return false;
        }
    }
}
