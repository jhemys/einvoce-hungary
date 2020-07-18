using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace eInvoice.Hungary.Infrastructure.NoSQL.Models
{
    public class Invoice
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string InvoiceKey { get; set; }
        public InvoiceData InvoiceData { get; set; }
    }
}
