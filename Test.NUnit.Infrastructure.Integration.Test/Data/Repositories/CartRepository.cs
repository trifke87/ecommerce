using Core.Entities;
using Core.Interfaces;
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
        private readonly ICartRepository _repo;

        //public CartRepository(ICartRepository repo)
        //{
        //    _repo = repo;
        //}

        [Test]
        public async Task AddProductToCartAsync_ShouldReturnFalseWhenProductDoesntExist()
        {
            //var publisherServiceTest = new PublisherServiceTest();

            //await publisherServiceTest.Startup();

            //publisherServiceTest.CleanUp();
            await AddAsync(new Product { Id = 1, Name = "Chair", UnitPrice = 12, Quantity = 2 });

            await _repo.AddProductToCartAsync(1, 2, 3);
        }
    }
}
