using eInvoice.Hungary.Domain.AggregatesModel.InvoiceAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eInvoice.Hungary.Infrastructure.EntityConfiguration
{
    class InvoiceHistoryEntityTypeConfiguration : IEntityTypeConfiguration<InvoiceHistory>
    {
        public void Configure(EntityTypeBuilder<InvoiceHistory> builder)
        {
            builder.Property(history => history.Id)
               .ValueGeneratedOnAdd()
               .IsRequired();

            builder.Property(history => history.Status)
                .IsRequired();

            builder
                .Property(invoice => invoice.Date)
                .IsRequired();

            builder.Property(invoice => invoice.Description);
            builder.Property(history => history.Status);

            builder
                .HasOne(history => history.Invoice)
                .WithMany(invoice => invoice.History);
        }
    }
}
