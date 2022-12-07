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

                //order.ItemOrdered.ForEach((item) =>
                //{
                //    item.DiscountAmount = item.UnitPrice * order.Discount;
                //    item.UnitPrice = item.UnitPrice - item.DiscountAmount;
                //});
                order.ItemOrdered = thirtyDiscount.ItemOrdered;
                order.TotalAmount = thirtyDiscount.TotalAmount;
            }

            if (IsAnEvenDigit(lastNumber))
            {

            }
            else
            {

            }
            //if (IsAnOddDigit(lastNumber)) return 0.1m;


            return order;
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
