using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using eInvoice.Hungary.Domain.AggregatesModel.InvoiceAggregate;
using eInvoice.Hungary.Domain.AggregatesModel.InvoiceDataAggregate;
using eInvoice.Hungary.Application.Storage;

namespace eInvoice.Hungary.Application.Invoices.Commands.AddInvoice
{
    public class AddInvoiceCommandHandler : IRequestHandler<AddInvoiceCommand, CommandResult>
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IInvoiceDataRepository _invoiceDataRepository;
        private readonly IInvoiceDataReferenceRepository _invoiceDataReferenceRepository;
        private readonly IStorage _storage;
        public AddInvoiceCommandHandler(IInvoiceRepository invoiceRepository, IInvoiceDataRepository invoiceDataRepository, IInvoiceDataReferenceRepository invoiceDataReferenceRepository, IStorage storage)
        {
            _invoiceRepository = invoiceRepository;
            _invoiceDataRepository = invoiceDataRepository;
            _invoiceDataReferenceRepository = invoiceDataReferenceRepository;
            _storage = storage;
        }

        public async Task<CommandResult> Handle(AddInvoiceCommand request, CancellationToken cancellationToken)
        {
            var invoice = Invoice.Create(request.InvoiceNumber, request.InvoiceDate, request.CompanyCode, request.ReferenceId);

            try
            {

                //await _storage.UploadFile(new MemoryStream(Encoding.UTF8.GetBytes(request.ReferenceId)), "Test.xml", "test");


                var invoiceDataReference = InvoiceDataReference.Create(invoice, Guid.NewGuid());

                await _invoiceRepository.AddAsync(invoice);
                await _invoiceDataReferenceRepository.AddAsync(invoiceDataReference);

                await _invoiceRepository.UnitOfWork.SaveEntitiesAsync();

                request.InvoiceData.InvoiceId = invoice.Id;
                await _invoiceDataRepository.AddAsync(request.InvoiceData);

                invoice.Change(request.InvoiceData.Id, invoice.CurrentStatus);
                invoiceDataReference.Change(request.InvoiceData.Id);

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
