using MediatR;
using System.Collections.Generic;
using eInvoice.Hungary.Application.Invoices.Queries.GetInvoice;

namespace eInvoice.Hungary.Application.Invoices.Queries.GetInvoices
{
    public class GetInvoicesQuery : IRequest<InvoicesResult>
    {
    }
}
