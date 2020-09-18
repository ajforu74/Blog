using System;

namespace EFConstructor.Console.Models
{
    public class Customer
    {
        public string Name { get; }
        public string Email { get; private set; }
        public string Address { get; private set; }

        private Customer() { }

        public Customer(string name, string email, string address)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Address = address ?? throw new ArgumentNullException(nameof(address));
        }
    }
}
