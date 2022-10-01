using Core.Common;
using Core.Entities;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IOrderRepository
    {
        Task<RValue<Order>> CreateOrder(int customerId, Address address, string phoneNumber);
    }
}