using Microsoft.EntityFrameworkCore;

namespace EFConstructor.Console.Models
{
    public class QuoteContext : DbContext
    {
        public QuoteContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Quote> Quotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var quoteConfiguration = modelBuilder.Entity<Quote>();
            quoteConfiguration.ToTable("Quote");

            quoteConfiguration.OwnsOne(a => a.Customer, builder =>
            {
                builder.Property(c => c.Name).HasColumnName("CustomerName");
                builder.Property(c => c.Email).HasColumnName("Email");
                builder.Property(c => c.Address).HasColumnName("Address");
            });

            quoteConfiguration.OwnsOne(a => a.Phone, builder =>
            {
                builder.Property(c => c.Name).HasColumnName("PhoneName");
                builder.Property(c => c.ModelNo).HasColumnName("PhoneModelNo");
                builder.Property(c => c.Price).HasColumnName("PhonePrice");
            });
        }

    }
}
