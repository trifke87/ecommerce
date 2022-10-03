using Core.Common;
using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Infrastructure.Data.Validations
{
    public class OrderValidation : IOrderValidation
    {
        public const string motif = @"^[\+]{0,1}[0-9]{1,}$";

        public RValue<bool> CreateOrderValidation(int customerId, Address address, string phoneNumber)
        {
            if (customerId <= 0)
                return new RValue<bool>(false, "customerId cannot be less than 1");

            if (address.City == null || address.Street == null || address.HouseNumber == null 
                || address.City.Length == 0 || address.HouseNumber.Length == 0 || address.Street.Length == 0)
                return new RValue<bool>(false, "Address info are required");

            if (PhoneNumberValidation(phoneNumber) == false)
                return new RValue<bool>(false, "Phone number is not in a valid format. Phone number can " +
                    "contain only numbers from 0 to 9. Example: 12144379402.");

            return new RValue<bool>(true) { Value = true };
        }

        private bool PhoneNumberValidation(string phoneNumber)
        {
            if (phoneNumber == null)
                return false;

            if (phoneNumber.Length > 0)
                return Regex.IsMatch(phoneNumber, motif);
            else
                return false;
        }
    }
}
