using System;
using System.Collections.Generic;
using eInvoice.Hungary.Domain.AggregatesModel.InvoiceDataAggregate;
using eInvoice.Hungary.Domain.SeedWork;

namespace eInvoice.Hungary.Domain.AggregatesModel.InvoiceAggregate
{
    public class Invoice : Entity<int>, IAggregateRoot
    {
        public string InvoiceNumber { get; private set; }
        public DateTime Date { get; private set; }
        public string CompanyCode { get; private set; }
        public string ReferenceId { get; private set; }
        public Guid? CurrentInvoiceDataId { get; private set; }
        public InvoiceStatus CurrentStatus { get; private set; }
        public InvoiceData InvoiceData { get; private set; }
        public IEnumerable<InvoiceHistory> History { get; private set; }
        public IEnumerable<InvoiceDataReference> InvoiceDataReference { get; private set; }

        private Invoice(int id)
            : base(id) { }

        public Invoice() { }

        private Invoice(string invoiceNumber, DateTime invoiceDate, string companyCode, string referenceId, InvoiceStatus currentStatus)
        {
            InvoiceNumber = invoiceNumber;
            Date = invoiceDate;
            CompanyCode = companyCode;
            ReferenceId = referenceId;
            CurrentStatus = currentStatus;
        }

        public static Invoice Load(int id) =>
            new Invoice(id);

        public static Invoice Create(string invoiceNumber, DateTime invoiceDate, string companyCode, string referenceId, InvoiceStatus currentStatus = InvoiceStatus.Received) => new Invoice(invoiceNumber, invoiceDate, companyCode, referenceId, currentStatus);

        public Invoice Change(Guid invoiceDataId, InvoiceStatus status)
        {
            if (invoiceDataId == Guid.Empty) throw new ArgumentException("You must provide a InvoiceDataId");
            
            CurrentInvoiceDataId = invoiceDataId;
            CurrentStatus = status;

            return this;
        }
    }
}
