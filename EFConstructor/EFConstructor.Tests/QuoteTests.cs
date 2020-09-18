using AutoFixture;
using AutoFixture.Xunit2;
using EFConstructor.Console.Models;
using System;
using Xunit;

namespace EFConstructor.Tests
{
    public class QuoteTests
    {
        [Fact]
        public void OpenQuoteSetsStatusToOpen()
        {
            var customer = new Customer(
                "Rahul", "rahul@rahul.com", "123 Fake Address");
            var quote = new Quote(Guid.NewGuid(), customer);
            var phone = new MobilePhone("IPhone", "X", 1000.00m);
            quote.UpdatePhone(phone);

            quote.OpenQuote();

            Assert.Equal(QuoteStatus.Open, quote.Status);
        }

        [Fact]
        public void OpenQuoteSetsStatusToOpen1()
        {
            var customer = new Customer(
                "Rahul", "rahul@rahul.com", "123 Fake Address");
            var phone = new MobilePhone("IPhone", "X", 1000.00m);
            var quote = new Quote(Guid.NewGuid(), customer, phone, QuoteStatus.Draft);

            quote.OpenQuote();

            Assert.Equal(QuoteStatus.Open, quote.Status);
        }
    }
}
