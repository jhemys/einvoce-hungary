using eInvoice.Hungary.Application.Invoices.Queries;
using eInvoice.Hungary.Domain.AggregatesModel.InvoiceAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace eInvoice.Hungary.Application.Invoices.Commands.DeleteInvoice
{
    public class DeleteInvoiceCommandHandler : IRequestHandler<DeleteInvoiceCommand, CommandResult>
    {
        private readonly IInvoiceQuery _invoiceQuery;
        private readonly IInvoiceRepository _invoiceRepository;

        public DeleteInvoiceCommandHandler(IInvoiceRepository invoiceRepository, IInvoiceQuery invoiceQuery)
        {
            _invoiceRepository = invoiceRepository;
            _invoiceQuery = invoiceQuery;
        }


        public async Task<CommandResult> Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
        {
            var existingInvoice = await _invoiceQuery.GetInvoiceAsync(request.InvoiceId);

            if (existingInvoice.Id <= 0)
                return CommandResult.Fail("The informed Id does not exist");

            try
            {
                _invoiceRepository.Remove(existingInvoice);

                await _invoiceRepository.UnitOfWork.SaveEntitiesAsync();
            }
            catch (Exception ex)
            {
                return CommandResult.Fail(ex.Message);
            }
                
            return CommandResult.Ok("The Invoice was successfully deleted.");
        }
    }
}
