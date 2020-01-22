using Microsoft.EntityFrameworkCore;
using eInvoice.Hungary.Infrastructure.EntityConfigurations;
using eInvoice.Hungary.Domain.Model.AggregatesModel.InvoiceAggregate;
using eInvoice.Hungary.Domain.SeedWork;
using System.Threading.Tasks;

namespace eInvoice.Hungary.Infrastructure.WriteModel.Context
{
    public class InvoiceContext : DbContext, IUnitOfWork
    {
        public InvoiceContext(DbContextOptions<InvoiceContext> options)
            : base(options) { }

        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new InvoiceEntityTypeConfiguration());
        }

        public async Task SaveEntitiesAsync()
        {
            await base.SaveChangesAsync();
        }
    }
}
