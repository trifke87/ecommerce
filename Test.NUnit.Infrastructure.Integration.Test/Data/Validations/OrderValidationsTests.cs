using Infrastructure.Data.Validations;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.NUnit.Infrastructure.Integration.Test.Data.Validations
{
    public class OrderValidationsTests
    {
        [Test]
        public void CreateOrderValidation_CategoryIdLessThanOne_ReturnFalse()
        {
            var val = new OrderValidation();
            var result = val.CreateOrderValidation(0, new Core.Entities.Address { City = "Beograd", HouseNumber = "1", Street = "Kralja Milana" }, "011555333");

            Assert.IsFalse(result.Success);
        }

        [Test]
        public void CreateOrderValidation_PhonNumberInvalidFormat_ReturnFalse()
        {
            var val = new OrderValidation();
            var result = val.CreateOrderValidation(1, new Core.Entities.Address { City = "Beograd", HouseNumber = "1", Street = "Kralja Milana" }, "0115a55333");

            Assert.IsFalse(result.Success);
        }

        [Test]
        public void CreateOrderValidation_PhonNumberIsEmpty_ReturnFalse()
        {
            var val = new OrderValidation();
            var result = val.CreateOrderValidation(1, new Core.Entities.Address { City = "Beograd", HouseNumber = "1", Street = "Kralja Milana" }, "");

            Assert.IsFalse(result.Success);
        }

        [Test]
        public void CreateOrderValidation_CityProprtyIsEmpty_ReturnFalse()
        {
            var val = new OrderValidation();
            var result = val.CreateOrderValidation(1, new Core.Entities.Address { City = "", HouseNumber = "1", Street = "Kralja Milana" }, "011555333");

            Assert.IsFalse(result.Success);
        }

        [Test]
        public void CreateOrderValidation_CityProprtyNotProvided_ReturnFalse()
        {
            var val = new OrderValidation();
            var result = val.CreateOrderValidation(1, new Core.Entities.Address { HouseNumber = "1", Street = "Kralja Milana" }, "011555333");

            Assert.IsFalse(result.Success);
        }

        [Test]
        public void CreateOrderValidation_HousNumberProprtyIsEmpty_ReturnFalse()
        {
            var val = new OrderValidation();
            var result = val.CreateOrderValidation(1, new Core.Entities.Address { City = "Beograd", HouseNumber = "", Street = "Kralja Milana" }, "011555333");

            Assert.IsFalse(result.Success);
        }

        [Test]
        public void CreateOrderValidation_HousNumberProprtyNotProvided_ReturnFalse()
        {
            var val = new OrderValidation();
            var result = val.CreateOrderValidation(1, new Core.Entities.Address { City = "Beograd", Street = "Kralja Milana" }, "011555333");

            Assert.IsFalse(result.Success);
        }

        [Test]
        public void CreateOrderValidation_StreetProprtyIsEmpty_ReturnFalse()
        {
            var val = new OrderValidation();
            var result = val.CreateOrderValidation(1, new Core.Entities.Address { City = "Beograd", HouseNumber = "1", Street = "" }, "011555333");

            Assert.IsFalse(result.Success);
        }

        [Test]
        public void CreateOrderValidation_StreetProprtyNotProvided_ReturnFalse()
        {
            var val = new OrderValidation();
            var result = val.CreateOrderValidation(1, new Core.Entities.Address { City = "Beograd", HouseNumber = "1"}, "011555333");

            Assert.IsFalse(result.Success);
        }

        [Test]
        public void CreateOrderValidation_AllPropertiesProvided_ReturnTrue()
        {
            var val = new OrderValidation();
            var result = val.CreateOrderValidation(1, new Core.Entities.Address { City = "Beograd", HouseNumber = "1", Street = "Kralja Milana" }, "011555333");

            Assert.IsTrue(result.Success);
        }
    }
}
