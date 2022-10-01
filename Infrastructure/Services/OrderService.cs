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

            var result = 0m;

            if (lastNumber == 0) return 0.3m;
            if (lastNumber % 2 != 0) return 0.2m;
            if (lastNumber % 2 == 0) return 0.1m;

            //result = IsAnOddDigit(lastNumber);
            //result = IsAnEvenDigit(lastNumber);
            //result = EndWithZero(lastNumber);

            return result;
        }

        private decimal IsAnOddDigit(int lastNumber)
        {
            if (lastNumber % 2 == 0)
                return 0.1m;
            return 0;
        }

        private decimal IsAnEvenDigit(int lastNumber)
        {
            if (lastNumber % 2 != 0)
                return 0.2m;
            return 0;
        }

        private decimal EndWithZero(int lastNumber)
        {
            if (lastNumber == 0)
                return 0.3m;
            return 0;
        }
    }
}
