using Core.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.NUnit.Infrastructure.Integration.Test.Data.Repositories
{
    using static Testing;
    public class CartRepository
    {
        [Test]
        public async Task AddProductToCartAsync_ShouldReturnFalseWhenProductDoesntExist()
        {
            await AddAsync(new Product { Id = 1, Name = "Table", Quantity = 1, UnitPrice = 12 });


        }
    }
}
