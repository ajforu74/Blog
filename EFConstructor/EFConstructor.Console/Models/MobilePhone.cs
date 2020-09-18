using System;

namespace EFConstructor.Console.Models
{
    public class MobilePhone
    {
        public static MobilePhone Empty => new MobilePhone();

        public string Name { get; private set; }
        public string ModelNo { get; private set; }
        public decimal Price { get; private set; }

        private MobilePhone() { }

        public MobilePhone(string name, string modelNo, decimal price)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            ModelNo = modelNo ?? throw new ArgumentNullException(nameof(modelNo));
            Price = price;
        }
    }
}