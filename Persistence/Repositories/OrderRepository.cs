using Domain.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal sealed class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Order order)
        {
            _context.Orders.Add(order);
        }

        public Task<Order?> GetByIdWithLineItemsAsync(OrderId id, LineItemId lineItemId)
        {
            return _context.Orders
                .Include(o => o.LineItems.Where(li => li.Id == lineItemId))
                .SingleOrDefaultAsync(o => o.Id == id);
        }
    }
}
