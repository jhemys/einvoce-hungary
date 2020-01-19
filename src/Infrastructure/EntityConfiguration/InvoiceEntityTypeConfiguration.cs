using eInvoice.Hungary.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
        }
    }
}
