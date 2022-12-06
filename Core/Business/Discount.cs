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
        public OrderItem CalculateDiscount(OrderItem orderItem, string phoneNumber)
        {
            var lastNumberChar = phoneNumber[phoneNumber.Length - 1];
            int lastNumber = 0;
            var isParsed = int.TryParse(lastNumberChar.ToString(), out lastNumber);

            if (isParsed == false)
                return orderItem;

            if (IsEndWithZero(lastNumber)) 
            {
                var thirtyDiscount = new ThirtyPercentDecorator(orderItem);
                orderItem.Discount = thirtyDiscount.Discount;
                orderItem.DiscountAmount = thirtyDiscount.DiscountAmount;
                orderItem.UnitPrice = thirtyDiscount.UnitPrice;
            }

            if (IsAnEvenDigit(lastNumber))
            {

            }
            else
            {

            }
            //if (IsAnOddDigit(lastNumber)) return 0.1m;


            return orderItem;
        }

        //private bool IsAnOddDigit(int lastNumber)
        //{
        //    return lastNumber % 2 != 0 ? true : false;
        //}

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
