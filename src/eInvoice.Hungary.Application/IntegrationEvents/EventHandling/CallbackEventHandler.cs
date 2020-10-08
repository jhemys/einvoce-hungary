using eInvoice.Hungary.Application.IntegrationEvents.Events;
using eInvoice.Hungary.Application.Invoices.Queries;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace eInvoice.Hungary.Application.IntegrationEvents.EventHandling
{
    public class CallbackEventHandler : IIntegrationEventHandler<CallbackEvent>
    {
        private readonly IMediator _mediator;
        private readonly IInvoiceQuery _invoiceQuery;
        private readonly ILogger<CallbackEventHandler> _logger;

        public CallbackEventHandler(IMediator mediator, IInvoiceQuery invoiceQuery, ILogger<CallbackEventHandler> logger)
        {
            _mediator = mediator;
            _invoiceQuery = invoiceQuery;
            _logger = logger;
        }

        public async Task Handle(CallbackEvent @event)
        {
            _logger.LogInformation("Test");
        }
    }
}