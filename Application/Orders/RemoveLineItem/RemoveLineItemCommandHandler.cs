using Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.RemoveLineItem
{
    internal class RemoveLineItemCommandHandler : IRequestHandler<RemoveLineItemCommand>
    {
        private readonly IApplicationDbContext _context;

        public RemoveLineItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveLineItemCommand request, CancellationToken cancellationToken)
        {
            var order = await _context
                .Orders
                .Include(o => o.LineItems.Where(li => li.OrderId == request.OrderId)) // filtrelenmiş include ile önemli bir performans artışı sağladık
                // .AsSplitQuery() // performans için önemli; iki sorgu çalışır birisi order'ı getirmek için diğeri ise bu order'a bağlı olan lineitems'ı getirmek için. order null dönerse lineitems için sorgu yapmamızı önler
                .SingleOrDefaultAsync(o => o.Id == request.OrderId, cancellationToken);

            if(order is null)
            {
                return;
            }

            order.RemoveLineItem(request.LineItemId);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
