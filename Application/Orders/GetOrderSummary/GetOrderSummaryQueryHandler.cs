using Application.Data;
using Domain.Orders;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.GetOrderSummary
{
    internal sealed class GetOrderSummaryQueryHandler : IRequestHandler<GetOrderSummaryQuery, OrderSummary?>
    {
        private readonly IApplicationDbContext _context;

        public GetOrderSummaryQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<OrderSummary?> Handle(GetOrderSummaryQuery request, CancellationToken cancellationToken)
        {
            return await _context.OrderSummaries
                .AsNoTracking() // performans ve optimizasyon için, readonly sorgularda asNoTracking etkili olur
                .FirstOrDefaultAsync(o => o.OrderId == request.OrderId, cancellationToken);
        }
    }
}
