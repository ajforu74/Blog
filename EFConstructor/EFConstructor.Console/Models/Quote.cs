using System;
using System.Collections.Generic;

namespace EFConstructor.Console.Models
{
    public class Quote
    {
        public Guid Id { get; private set; }
        public QuoteStatus Status { get; private set; }
        public Customer Customer { get; }
        public MobilePhone Phone { get; private set; }
        private readonly List<Accessorry> _accessories = new List<Accessorry>();
        public IReadOnlyCollection<Accessorry> Accessories => _accessories;

        private Quote() { }

        public Quote(Guid id, Customer customer)
            : this(id, customer, MobilePhone.Empty, QuoteStatus.Draft) { }

        public Quote(Guid id, Customer customer, MobilePhone phone, QuoteStatus status)
        {
            Id = id;
            Customer = customer ?? throw new ArgumentNullException(nameof(customer));
            Phone = phone ?? throw new ArgumentNullException(nameof(phone));

            if (status != QuoteStatus.Draft && phone == MobilePhone.Empty)
                throw new DomainException($"Cannot set quote to {status} with empty phone");

            Status = status;
        }

        public void UpdatePhone(MobilePhone phone)
        {
            Phone = phone ?? throw new ArgumentNullException(nameof(phone));
        }

        public void AddAccessory(Accessorry accessorry)
        {
            if (accessorry == null)
                throw new ArgumentNullException(nameof(accessorry));

            _accessories.Add(accessorry);
        }

        public void OpenQuote()
        {
            if (Phone == MobilePhone.Empty)
                throw new DomainException("Cannot set quote to open with empty phone");

            Status = QuoteStatus.Open;
        }
    }

    public enum QuoteStatus
    {
        Draft,
        Open,
        Accepted,
        Expired
    }
}
