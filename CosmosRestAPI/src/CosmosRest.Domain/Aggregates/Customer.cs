using System;

namespace CosmosRest.Domain.Aggregates
{
    public class Customer 
    {
        public Guid Id { get; set; }
        public string Name { get; private set; }
        public string Address { get; private set; }
        public int Age { get; private set; }
    }
}