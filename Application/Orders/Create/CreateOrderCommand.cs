using Domain.Customers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.Create
{
    public class CreateOrderCommand : IRequest
    {
        public Guid CustomerId { get; set; }
    }
}
