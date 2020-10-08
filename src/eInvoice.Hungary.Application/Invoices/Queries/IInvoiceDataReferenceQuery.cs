using eInvoice.Hungary.Domain.AggregatesModel.InvoiceAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eInvoice.Hungary.Application.Invoices.Queries
{
    public interface IInvoiceDataReferenceQuery
    {
        Task<InvoiceDataReference> GetInvoiceDataReferenceByInvoiceDataId(Guid invoiceDataId);
    }
}
