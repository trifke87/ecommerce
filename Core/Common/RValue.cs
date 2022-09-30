using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common
{
    public class RValue<T>
    {
        public T Value { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public RValue()
        {

        }

        public RValue(bool success)
        {
            Success = success;
        }

        public RValue(bool success, string errorMessage)
        {
            Success = success;
            ErrorMessage = errorMessage;
        }
    }
}
