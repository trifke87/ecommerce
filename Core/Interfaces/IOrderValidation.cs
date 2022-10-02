using Core.Common;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IOrderValidation
    {
        RValue<bool> CreateOrderValidation(int customerId, Address address, string phoneNumber);
    }
}