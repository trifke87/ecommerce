using Infrastructure.Data.Validations;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.NUnit.Infrastructure.Integration.Test.Data.Validations
{
    public class CartValidatorTests
    {
        [Test]
        public void AddToShopingCartValidate_CustomerIdLessThanOne_ReturnFalse()
        {
            var val = new CartValidator();
            var result = val.AddToShopingCartValidate(0, 1, 1);

            Assert.IsFalse(result.Success);
        }

        [Test]
        public void AddToShopingCartValidate_ProductIdIdLessThanOne_ReturnFalse()
        {
            var val = new CartValidator();
            var result = val.AddToShopingCartValidate(1, 0, 1);

            Assert.IsFalse(result.Success);
        }

        [Test]
        public void AddToShopingCartValidate_QuantityLessThanOne_ReturnFalse()
        {
            var val = new CartValidator();
            var result = val.AddToShopingCartValidate(1, 1, 0);

            Assert.IsFalse(result.Success);
        }

        [Test]
        public void AddToShopingCartValidate_AllParametersProvidedCorrectly_ReturnTrue()
        {
            var val = new CartValidator();
            var result = val.AddToShopingCartValidate(1, 1, 1);

            Assert.IsTrue(result.Success);
        }

        [Test]
        public void GetCartContentValidate_CartIdLessThanOne_ReturnFalse()
        {
            var val = new CartValidator();
            var result = val.GetCartContentValidate(0);

            Assert.IsFalse(result.Success);
        }

        [Test]
        public void GetCartContentValidate_AllParametersProvidedCorrectly_ReturnTrue()
        {
            var val = new CartValidator();
            var result = val.GetCartContentValidate(1);

            Assert.IsTrue(result.Success);
        }
    }
}
