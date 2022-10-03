using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
     public class OrderService : IOrderService
    {
        public decimal DiscountRate(string phoneNumber)
        {
            var lastNumberChar = phoneNumber[phoneNumber.Length - 1];
            int lastNumber = 0;
            var isParsed = int.TryParse(lastNumberChar.ToString(), out lastNumber);

            if (isParsed == false)
                return 0;

            if (IsEndWithZero(lastNumber)) return 0.3m;
            if (IsAnEvenDigit(lastNumber)) return 0.2m;
            if (IsAnOddDigit(lastNumber)) return 0.1m;

            return 0;
        }

        private bool IsAnOddDigit(int lastNumber)
        {
            return lastNumber % 2 != 0 ? true : false;
        }

        private bool IsAnEvenDigit(int lastNumber)
        {
            return lastNumber % 2 == 0 ? true : false;
        }

        private bool IsEndWithZero(int lastNumber)
        {
            return lastNumber == 0 ? true : false;
        }
    }
}
