using System.Threading.Tasks;

namespace eInvoice.Hungary.Infrastructure.EventBus.Abstractions
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
