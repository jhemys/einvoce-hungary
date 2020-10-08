using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using eInvoice.Hungary.Domain.AggregatesModel.InvoiceAggregate;
using eInvoice.Hungary.Application.Invoices.Queries;

namespace eInvoice.Hungary.Application.Invoices.Commands.AddInvoiceHistory
{
    public class AddInvoiceHistoryCommandHandler : IRequestHandler<AddInvoiceHistoryCommand, CommandResult>
    {
        private readonly IInvoiceDataReferenceQuery _invoiceDataReferenceQuery;
        private readonly IInvoiceDataReferenceRepository _invoiceDataReferenceRepository;
        public AddInvoiceHistoryCommandHandler(IInvoiceDataReferenceQuery invoiceDataReferenceQuery, IInvoiceDataReferenceRepository invoiceDataReferenceRepository)
        {
            _invoiceDataReferenceQuery = invoiceDataReferenceQuery;
            _invoiceDataReferenceRepository = invoiceDataReferenceRepository;
        }
        public async Task<CommandResult> Handle(AddInvoiceHistoryCommand request, CancellationToken cancellationToken)
        {
            var invoiceDataReference = await _invoiceDataReferenceQuery.GetInvoiceDataReferenceByInvoiceDataId(request.InvoiceDataId);

            if (invoiceDataReference != null)
            {
            }

            return CommandResult.Ok();
        }
    }
}
