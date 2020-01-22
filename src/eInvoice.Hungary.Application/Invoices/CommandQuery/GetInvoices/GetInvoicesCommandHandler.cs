using eInvoice.Hungary.Application.Invoices.CommandQuery.GetInvoice;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace eInvoice.Hungary.Application.Invoices.CommandQuery.GetInvoices
{
    public class GetInvoicesCommandHandler : IRequestHandler<GetInvoicesQuery, InvoicesResult>
    {
        private readonly IInvoiceQuery _invoiceQuery;

        public GetInvoicesCommandHandler(IInvoiceQuery invoiceQuery)
            => _invoiceQuery = invoiceQuery;

        public async Task<InvoicesResult> Handle(GetInvoicesQuery request, CancellationToken cancellationToken)
        {
            var invoices = await _invoiceQuery.GetInvoices();

            return new InvoicesResult(invoices);
        }
    }
}
