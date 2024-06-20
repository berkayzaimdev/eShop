using Domain.Orders;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.Create
{
    internal sealed class OrderCreatedDomainEventHandler : INotificationHandler<OrderCreatedDomainEvent>
    {
        public async Task Handle(OrderCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            // rebus will be integrated
            throw new NotImplementedException();
        }
    }
}
