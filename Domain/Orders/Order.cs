﻿using Domain.Customers;
using Domain.Primitives;
using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Orders
{
    public class Order : Entity
    {
        private readonly HashSet<LineItem> _lineItems = new ();
        private Order()
        {

        }

        public OrderId Id { get; private set; }
        public CustomerId CustomerId { get; private set; }
        public IReadOnlyList<LineItem> LineItems => _lineItems.ToList();

        public static Order Create(CustomerId customerId)
        {
            var order = new Order
            {
                Id = new OrderId(Guid.NewGuid()),
                CustomerId = customerId
            };

            order.Raise(new OrderCreatedDomainEvent(Guid.NewGuid(), order.Id));

            return order;
        }

        public void Add(ProductId productId, Money price)
        {
            var lineItem = new LineItem(
                new LineItemId(Guid.NewGuid()), 
                Id,
                productId, 
                price);

            _lineItems.Add(lineItem);
        }

        public void RemoveLineItem(LineItemId lineItemId)
        {
            var lineItem = _lineItems.FirstOrDefault(x => x.Id == lineItemId);

            if(lineItem is null)
            {
                return;
            }

            _lineItems.Remove(lineItem);

            Raise(new LineItemRemovedDomainEvent(Guid.NewGuid(), Id, lineItem.Id));
        }
    }
}
