using MediatR;
using System.Collections.Generic;
using eInvoice.Hungary.Application.Invoices.CommandQuery.GetInvoice;

namespace eInvoice.Hungary.Application.Invoices.CommandQuery.GetInvoices
{
    public class GetInvoicesQuery : IRequest<InvoicesResult>
    {
    }
}
