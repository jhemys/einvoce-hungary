using System;
using RabbitMQ.Client;

namespace eInvoice.Hungary.Infrastructure.EventBus.Abstractions
{
    public interface IRabbitMQConnection
        : IDisposable
    {
        bool IsConnected { get; }

        bool TryConnect();

        IModel CreateModel();
    }
}
