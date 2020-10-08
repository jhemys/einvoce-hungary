using System.Collections.Generic;

namespace eInvoice.Hungary.Application.IntegrationEvents.Events
{
    public class CallbackEvent : IntegrationEvent
    {
        public CallbackEvent(string endpointUrl, string token)
        {
            EndpointUrl = endpointUrl;
            Token = token;
        }

        public string EndpointUrl { get; set; }
        public string Token { get; set; }
        public List<CallbackFields> Fields { get; set; }
    }

    public class CallbackFields
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
