using eInvoice.Hungary.Domain.AggregatesModel.InvoiceDataAggregate;
using eInvoice.Hungary.Infrastructure.NoSQL.Abstractions;

namespace eInvoice.Hungary.Infrastructure.WriteModel.Repositories
{
    public class InvoiceDataRepository : BaseMongoRepository<InvoiceData>, IInvoiceDataRepository
    {
        public InvoiceDataRepository(IMongoContext mongoContext) : base(mongoContext) { }
    }
}
