using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Services;
using NUnit.Framework;

namespace Test.NUnit.Infrastructure.Integration.Test.Service
{
    public class OrderServiceTests
    {
        [Test]
        public void DiscountRate_PhoneNumberEndsWithZero_Return30Percent()
        {
            decimal expect = 0.3m;

            var orderService = new OrderService();
            var result = orderService.DiscountRate("011552230");

            Assert.AreEqual(expect, result);
        }

        [Test]
        public void DiscountRate_PhoneNumberEndsWithOddDigit_Return10Percent()
        {
            decimal expect = 0.1m;

            var orderService = new OrderService();
            var result = orderService.DiscountRate("011552231");

            Assert.AreEqual(expect, result);
        }

        [Test]
        public void DiscountRate_PhoneNumberEndsWithEvenDigit_Return20Percent()
        {
            decimal expect = 0.2m;

            var orderService = new OrderService();
            var result = orderService.DiscountRate("011552232");

            Assert.AreEqual(expect, result);
        }

        [Test]
        public void DiscountRate_PhoneNumberEndsWithIncorrectChar_ReturnZero()
        {
            var expect = 0;

            var orderService = new OrderService();
            var result = orderService.DiscountRate("01155223a");

            Assert.AreEqual(expect, result);
        }
    }
}
