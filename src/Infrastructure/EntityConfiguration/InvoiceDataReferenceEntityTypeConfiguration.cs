using eInvoice.Hungary.Domain.AggregatesModel.InvoiceAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eInvoice.Hungary.Infrastructure.EntityConfiguration
{
    class InvoiceDataReferenceEntityTypeConfiguration : IEntityTypeConfiguration<InvoiceDataReference>
    {
        public void Configure(EntityTypeBuilder<InvoiceDataReference> builder)
        {
            builder.Property(invoiceDataReference => invoiceDataReference.Id)
               .ValueGeneratedOnAdd()
               .IsRequired();

            builder
                .Property(invoice => invoice.Date)
                .IsRequired();

            builder
                .Property(invoice => invoice.InvoiceDataId)
                .IsRequired();

            builder
                .HasOne(invoiceDataReference => invoiceDataReference.Invoice)
                .WithMany(invoice => invoice.InvoiceDataReference);

            builder.Ignore(invoiceDataReference => invoiceDataReference.InvoiceData);
        }
    }
}
