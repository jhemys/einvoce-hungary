using System;

namespace eInvoice.Hungary.Application.IntegrationEvents
{
    public class IntegrationEvent
    {
        public IntegrationEvent()
        {
            new IntegrationEvent(Guid.NewGuid(), DateTime.UtcNow);
        }

        public IntegrationEvent(Guid id, DateTime createDate)
        {
            Id = id;
            CreationDate = createDate;
        }

        public Guid Id { get; private set; }
        public DateTime CreationDate { get; private set; }
    }
}
