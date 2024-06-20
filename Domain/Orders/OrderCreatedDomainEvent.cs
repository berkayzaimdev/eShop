using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Orders
{
    public record OrderCreatedDomainEvent(Guid Id, OrderId OrderId) : DomainEvent(Id);
}
