using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Orders
{
    public interface IOrderRepository
    {
        Task<Order?> GetByIdWithLineItemsAsync(OrderId id, LineItemId lineItemId);
        void Add(Order order);
    }
}
