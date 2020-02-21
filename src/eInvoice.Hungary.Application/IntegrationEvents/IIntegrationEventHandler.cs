using System.Threading.Tasks;

namespace eInvoice.Hungary.Application.IntegrationEvents
{
    public interface IIntegrationEventHandler<in TIntegrationEvent> : IIntegrationEventHandler
        where TIntegrationEvent: IntegrationEvent
    {
        Task Handle(IntegrationEvent @event);
    }

    public interface IIntegrationEventHandler
    {
    }
}
