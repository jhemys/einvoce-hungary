using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using eInvoice.Hungary.Domain.AggregatesModel.InvoiceAggregate;
using eInvoice.Hungary.Domain.Model.AggregatesModel.InvoiceAggregate;

namespace eInvoice.Hungary.Application.Invoices.Commands.AddInvoice
{
    public class AddInvoiceCommandHandler : IRequestHandler<AddInvoiceCommand, CommandResult>
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IInvoiceDataRepository _invoiceDataRepository;
        public AddInvoiceCommandHandler(IInvoiceRepository invoiceRepository, IInvoiceDataRepository invoiceDataRepository)
        {
            _invoiceRepository = invoiceRepository;
            _invoiceDataRepository = invoiceDataRepository;
        }

        public async Task<CommandResult> Handle(AddInvoiceCommand request, CancellationToken cancellationToken)
        {
            var invoice = Invoice.Create(request.InvoiceNumber);
            var invoiceData = InvoiceData.Create(request.InvoiceDate);

            try
            {
                await _invoiceRepository.AddAsync(invoice);
                await _invoiceRepository.UnitOfWork.SaveEntitiesAsync();

                await _invoiceDataRepository.AddAsync(invoiceData);
            }
            catch (Exception ex)
            {
                return CommandResult.Fail(ex.ToString());
            }

            return CommandResult.Ok($"Invoice has been created successuful: [ {invoice.Id} ]");
        }
    }
}
