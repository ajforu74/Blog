using System;

namespace CosmosRest.Domain.Aggregates
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string OrderName { get;  set; }
        public string Address { get;  set; }
    }
}