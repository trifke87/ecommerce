using Core.Decorators;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business
{
    public class Discount
    {
        public Order CalculateDiscount(Order order, string phoneNumber)
        {
            var lastNumberChar = phoneNumber[phoneNumber.Length - 1];
            int lastNumber = 0;
            var isParsed = int.TryParse(lastNumberChar.ToString(), out lastNumber);

            if (isParsed == false)
                return order;

            if (IsEndWithZero(lastNumber)) 
            {
                var thirtyDiscount = new ThirtyPercentDecorator(order);
                order.Discount = thirtyDiscount.Discount;

                order.ItemOrdered = thirtyDiscount.ItemOrdered;
                order.TotalAmount = thirtyDiscount.TotalAmount;
            }

            if (IsAnEvenDigit(lastNumber))
            {
                var twentyDiscount = new TwentyPercentDecorator(order);
                order.Discount = twentyDiscount.Discount;

                order.ItemOrdered = twentyDiscount.ItemOrdered;
                order.TotalAmount = twentyDiscount.TotalAmount;
            }
            else
            {
                var tenDiscount = new TenPercentDecorator(order);
                order.Discount = tenDiscount.Discount;

                order.ItemOrdered = tenDiscount.ItemOrdered;
                order.TotalAmount = tenDiscount.TotalAmount;
            }

            return order;
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
