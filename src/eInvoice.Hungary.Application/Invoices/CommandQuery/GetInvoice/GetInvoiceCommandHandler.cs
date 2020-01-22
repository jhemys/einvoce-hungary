using eInvoice.Hungary.Domain.Model.AggregatesModel.InvoiceAggregate;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace eInvoice.Hungary.Application.Invoices.CommandQuery.GetInvoice
{
    public class GetInvoiceCommandHandler : IRequestHandler<GetInvoiceQuery, InvoiceResult>
    {
        private readonly IInvoiceQuery _invoiceQuery;

        public GetInvoiceCommandHandler(IInvoiceQuery invoiceQuery)
            => _invoiceQuery = invoiceQuery;

        public async Task<InvoiceResult> Handle(GetInvoiceQuery request, CancellationToken cancellationToken)
        {
            var invoice = await _invoiceQuery.GetInvoiceAsync(request.InvoiceId);

            InvoiceResult invoiceResult = null;

            if (invoice != null )
                invoiceResult = new InvoiceResult(invoice);

            return invoiceResult;
        }
    }
}
