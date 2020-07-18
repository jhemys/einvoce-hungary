using eInvoice.Hungary.Application.IntegrationEvents.Events;
using eInvoice.Hungary.Domain.AggregatesModel.InvoiceAggregate;
using eInvoice.Hungary.Domain.Model.AggregatesModel.InvoiceAggregate;
using Microsoft.Extensions.Logging;
using Serilog.Context;
using System.Threading.Tasks;

namespace eInvoice.Hungary.Application.IntegrationEvents.EventHandling
{
    public class InvoiceAcceptedEventHandler : IIntegrationEventHandler<InvoiceAcceptedEvent>
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly ILogger<InvoiceAcceptedEventHandler> _logger;

        public InvoiceAcceptedEventHandler(IInvoiceRepository invoiceRepository, ILogger<InvoiceAcceptedEventHandler> logger)
        {
            _invoiceRepository = invoiceRepository;
            _logger = logger;
        }

        public async Task Handle(InvoiceAcceptedEvent @event)
        {
            using (LogContext.PushProperty("IntegrationEventContext", $"{@event.Id}-Hungary"))
            {
                _logger.LogInformation("----- Handling integration event: {IntegrationEventId} at Hungary - ({@IntegrationEvent})", @event.Id, @event);

                var inovice = Invoice.Create("Test RabbitMQ " + System.Guid.NewGuid());

                await _invoiceRepository.AddAsync(inovice);
                await _invoiceRepository.UnitOfWork.SaveEntitiesAsync();
            }
        }
    }
}

