using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using eInvoice.Hungary.Domain.AggregatesModel.InvoiceAggregate;

namespace eInvoice.Hungary.Infrastructure.EntityConfigurations
{
    class InvoiceEntityTypeConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.Property(invoice => invoice.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(invoice => invoice.InvoiceNumber)
                .IsRequired();

            builder.Property(invoice => invoice.Date);
            builder.Property(invoice => invoice.CompanyCode)
                .HasMaxLength(100);
            builder.Property(invoice => invoice.CurrentInvoiceDataId);

            builder.Property(invoice => invoice.CurrentStatus);

            builder.Ignore(invoice => invoice.InvoiceData);
        }
    }
}
