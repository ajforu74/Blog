

using EFConstructor.Console.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EFConstructor.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World!");

            var optionsBuilder = new DbContextOptionsBuilder<QuoteContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Quotes;Trusted_Connection=True;MultipleActiveResultSets=true");

            var quoteId = Guid.NewGuid();
            using (var context = new QuoteContext(optionsBuilder.Options))
            {
                context.Database.EnsureCreated();

                var customer = new Customer("Rahul", "rahul@rahul.com", "123 Fake Address");
                var quote = new Quote(quoteId, customer);
                context.Quotes.Add(quote);
                context.SaveChanges();
            }

            using (var context = new QuoteContext(optionsBuilder.Options))
            {
                var quote = context.Quotes.First(a => a.Id == quoteId);
                var phone = new MobilePhone("IPhone", "X", 1000.00m);
                quote.UpdatePhone(phone);
                context.SaveChanges();
            }

            using (var context = new QuoteContext(optionsBuilder.Options))
            {
                var quote = context.Quotes.First(a => a.Id == quoteId);
                quote.OpenQuote();
                context.SaveChanges();
            }
        }
    }
}
