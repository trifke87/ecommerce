using Core.Entities;
using Core.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Data.Repositories;
using Infrastructure.Services;
using Infrastructure.Data;

namespace Test.NUnit.Infrastructure.Integration.Test.Data.Repositories
{
    using static Testing;
    public class CartRepositoryTest : TestBase
    {
        [Test]
        public async Task AddProductToCartAsync_ShouldReturnFalseWhenProductDoesntExist()
        {
            await AddAsync(new Product { Name = "Chair", UnitPrice = 12, Quantity = 2 });

        }
    }
}
