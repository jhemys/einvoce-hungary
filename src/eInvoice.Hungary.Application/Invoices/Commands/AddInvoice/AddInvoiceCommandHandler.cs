using eInvoice.Hungary.Domain.AggregatesModel.InvoiceAggregate;
using eInvoice.Hungary.Domain.Model.AggregatesModel.InvoiceAggregate;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace eInvoice.Hungary.Application.Invoices.Commands.AddInvoice
{
    public class AddInvoiceCommandHandler : IRequestHandler<AddInvoiceCommand, CommandResult>
    {
        private readonly IInvoiceRepository _invoiceRepository;
        public AddInvoiceCommandHandler(IInvoiceRepository invoiceRepository) => _invoiceRepository = invoiceRepository;

        public async Task<CommandResult> Handle(AddInvoiceCommand request, CancellationToken cancellationToken)
        {
            var invoice = Invoice.Create(request.InvoiceNumber);

            try
            {
                await _invoiceRepository.AddAsync(invoice);
                await _invoiceRepository.UnitOfWork.SaveEntitiesAsync();
            }
            catch (Exception ex)
            {
                return CommandResult.Fail(ex.ToString());
            }

            return CommandResult.Ok($"Invoice has been created successuful: [ {invoice.Id} ]");
        }
    }
}
