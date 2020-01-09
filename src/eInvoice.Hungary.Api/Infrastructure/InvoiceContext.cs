using eInvoice.Hungary.Api.Infrastructure.EntityConfigurations;
using eInvoice.Hungary.Api.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace eInvoice.Hungary.Api.Infrastructure
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

    public class InvoiceContextDesignFactory : IDesignTimeDbContextFactory<InvoiceContext>
    {
        public InvoiceContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<InvoiceContext>()
                .UseSqlServer("Server=.;Initial Catalog=Invoice;Integrated Security=true");

            return new InvoiceContext(optionsBuilder.Options);
        }
    }
}
