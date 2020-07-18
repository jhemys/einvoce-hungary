using System;
using System.Threading.Tasks;
using eInvoice.Hungary.Domain.AggregatesModel.InvoiceAggregate;
using eInvoice.Hungary.Domain.Model.AggregatesModel.InvoiceAggregate;
using eInvoice.Hungary.Domain.SeedWork;
using eInvoice.Hungary.Infrastructure.WriteModel.Context;
using Microsoft.EntityFrameworkCore;

namespace eInvoice.Hungary.Infrastructure.WriteModel.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly SqlContext _invoiceContext;
        public IUnitOfWork UnitOfWork => _invoiceContext;

        public InvoiceRepository(SqlContext invoiceContext)
            => _invoiceContext = invoiceContext ?? throw new ArgumentNullException($"'{nameof(invoiceContext)}'");

        public async Task AddAsync(Invoice invoice)
        {
            await _invoiceContext.AddAsync(invoice);
        }

        public void Remove(Invoice invoice)
        {
            _invoiceContext.Attach(invoice);
            _invoiceContext.Remove(invoice);
        }

        public void Update(Invoice invoice)
        {
            _invoiceContext.Attach(invoice);
            _invoiceContext.Entry(invoice).State = EntityState.Modified;
        }
    }
}
