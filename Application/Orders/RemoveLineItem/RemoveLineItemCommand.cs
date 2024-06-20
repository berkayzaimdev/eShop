using Domain.Orders;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.RemoveLineItem
{
    public record RemoveLineItemCommand(OrderId OrderId, LineItemId LineItemId) : IRequest;
}
