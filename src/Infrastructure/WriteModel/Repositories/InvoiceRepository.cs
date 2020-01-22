using System;
using System.Threading.Tasks;
using eInvoice.Hungary.Domain.AggregatesModel.InvoiceAggregate;
using eInvoice.Hungary.Domain.Model.AggregatesModel.InvoiceAggregate;
using eInvoice.Hungary.Domain.SeedWork;
using eInvoice.Hungary.Infrastructure.WriteModel.Context;

namespace eInvoice.Hungary.Infrastructure.WriteModel.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly InvoiceContext _invoiceContext;
        public IUnitOfWork UnitOfWork => _invoiceContext;

        public InvoiceRepository(InvoiceContext invoiceContext)
            => _invoiceContext = invoiceContext ?? throw new ArgumentNullException($"'{nameof(invoiceContext)}'");

        public async Task Add(Invoice invoice)
        {
            await _invoiceContext.AddAsync<Invoice>(invoice);
        }
    }
}
