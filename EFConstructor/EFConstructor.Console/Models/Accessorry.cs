using System;

namespace EFConstructor.Console.Models
{
    public class Accessorry
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Accessorry(Guid id, string name, decimal price)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Price = price;
        }
    }
}
