using MediatR;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace eInvoice.Hungary.Application.Invoices.Commands.AddInvoiceHistory
{
    public class AddInvoiceHistoryCommand : IRequest<CommandResult>
    {
        public Guid InvoiceDataId { get; }
        public DateTime LogDate { get; }
        public string Description { get; }
        public string ReferenceId { get; set; }
        public IReadOnlyCollection<InvoiceHistoryAttachment> Attachments { get; set; }

        public AddInvoiceHistoryCommand(Guid invoiceDataId, string description, DateTime? logDate = null, IEnumerable<InvoiceHistoryAttachment> historyAttachments = null)
        {
            LogDate = logDate ?? DateTime.UtcNow;
            Description = description;
            InvoiceDataId = invoiceDataId;
            Attachments = historyAttachments == null ? historyAttachments.ToImmutableList() : new List<InvoiceHistoryAttachment>().ToImmutableList();
        }

        public class InvoiceHistoryAttachment
        {
            public string FileName { get; set; }
            public string FileUrl { get; set; }
        }
    }
}
