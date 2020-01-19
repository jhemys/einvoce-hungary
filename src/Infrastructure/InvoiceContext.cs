using eInvoice.Hungary.Domain.Model;
using eInvoice.Hungary.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace eInvoice.Hungary.Infrastructure
{
    public class InvoiceContext : DbContext
    {
        public InvoiceContext(DbContextOptions<InvoiceContext> options) : base(options)
        {
        }

        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new InvoiceEntityTypeConfiguration());
        }
    }
}
