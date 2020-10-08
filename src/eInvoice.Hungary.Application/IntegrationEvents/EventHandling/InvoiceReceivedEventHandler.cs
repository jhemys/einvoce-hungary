using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using eInvoice.Hungary.Application.IntegrationEvents.Events;
using eInvoice.Hungary.Application.Invoices.Commands;
using eInvoice.Hungary.Application.Invoices.Commands.AddInvoice;
using eInvoice.Hungary.Application.Invoices.Queries;
using System;

namespace eInvoice.Hungary.Application.IntegrationEvents.EventHandling
{
    public class InvoiceReceivedEventHandler : IIntegrationEventHandler<InvoiceReceivedEvent>
    {
        private readonly IMediator _mediator;
        private readonly IInvoiceQuery _invoiceQuery;
        private readonly IEventBus _eventBus;
        private readonly ILogger<InvoiceReceivedEventHandler> _logger;

        public InvoiceReceivedEventHandler(IMediator mediator, IInvoiceQuery invoiceQuery, IEventBus eventBus, ILogger<InvoiceReceivedEventHandler> logger)
        {
            _mediator = mediator;
            _invoiceQuery = invoiceQuery;
            _eventBus = eventBus;
            _logger = logger;
        }

        public async Task Handle(InvoiceReceivedEvent @event)
        {
            try
            {
                var invoice = await _invoiceQuery.GetInvoiceByReferenceId(@event.ReferenceId);

                CommandResult commandResult;
                if (invoice == null)
                {
                    _logger.LogInformation("invoice found.");
                    var invoiceCommand = new AddInvoiceCommand(@event.InvoiceNumber, @event.InvoiceDate, @event.CompanyCode, @event.ReferenceId, @event.InvoiceData);

                    commandResult = await _mediator.Send(invoiceCommand);

                    if (commandResult.IsSuccess)
                    {

                    }
                    else
                    {

                    }
                }
                else
                {

                }

                var invoiceAccepted = new InvoiceAcceptedEvent(@event.ReferenceId, @event.InvoiceData.Id);
                _eventBus.Publish(invoiceAccepted);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
