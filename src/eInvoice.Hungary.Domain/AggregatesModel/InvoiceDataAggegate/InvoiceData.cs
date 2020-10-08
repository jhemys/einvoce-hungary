using System;
using System.Collections.Generic;
using eInvoice.Hungary.Domain.SeedWork;

namespace eInvoice.Hungary.Domain.AggregatesModel.InvoiceDataAggregate
{
    public class InvoiceData : Entity<Guid>
    {
        public Guid Guid { get; set; }
        public int InvoiceId { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceIssueDate { get; set; }
        public InvoiceMainData InvoiceMainData { get; set; }

        public InvoiceData() { }
        private InvoiceData(Guid id)
            : base(id) { }

        private InvoiceData(string invoiceNumber, DateTime invoiceIssueDate)
        {
            InvoiceIssueDate = invoiceIssueDate;
        }

        public static InvoiceData Load(Guid guid) =>
            new InvoiceData(guid);

        public static InvoiceData Create(string invoiceNumber, DateTime invoiceDate) => new InvoiceData(invoiceNumber, invoiceDate);

        //public static InvoiceData Create(string invoiceNumber, DateTime invoiceDate) => new InvoiceData(invoiceNumber, invoiceDate);

        public InvoiceData Change(DateTime invoiceIssueDate)
        {
            InvoiceIssueDate = invoiceIssueDate;

            return this;
        }
    }

    public class InvoiceMainData
    {
        public IEnumerable<InvoiceInformartion> Invoices { get; set; }

    }

    public class InvoiceInformartion
    {
        public InvoiceReference InvoiceReference { get; set; }
        public InvoiceHead InvoiceHead { get; set; }
        public IEnumerable<InvoiceLine> InvoiceLines { get; set; }
        public IEnumerable<ProductFeeSummary> ProductFeeSummaries { get; set; }
        public InvoiceSummary InvoiceSummary { get; set; }
    }

    public class InvoiceReference
    {
        public string OriginalInvoiceNumber { get; set; }
        public bool ModifyWithoutMaster { get; set; }
        public int ModificationIndex { get; set; }
    }

    public class InvoiceHead
    {
        public SupplierInfo SupplierInfo { get; set; }
        public CustomerInfo CustomerInfo { get; set; }
        public FiscalRepresentative FiscalRepresentativeInfo { get; set; }
        public InvoiceDetail InvoiceDetail { get; set; }
    }

    public class SupplierInfo
    {
        public TaxNumber SupplierTaxNumber { get; set; }
        public TaxNumber GroupMemberTaxNumber { get; set; }
        public string CommunityVatNumber { get; set; }
        public string SupplierName { get; set; }
        public Address SupplierAddress { get; set; }
        public string SupplierBankAccountNumber { get; set; }
        public bool IndividualExemption { get; set; }
        public string ExciseLicenceNum { get; set; }
    }


    public class CustomerInfo
    {
        public TaxNumber CustomerTaxNumber { get; set; }
        public TaxNumber GroupMemberTaxNumber { get; set; }
        public string CommunityVatNumber { get; set; }
        public string ThirdStateTaxId { get; set; }
        public string CustomerName { get; set; }
        public Address CustomerAddress { get; set; }
        public string CustomerBankAccountNumber { get; set; }
    }

    public class TaxNumber
    {
        public string TaxpayerId { get; set; }
        public string VatCode { get; set; }
        public string CountyCode { get; set; }
    }

    public class Address
    {
        public string CountryCode { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string AdditionalAddressDetail { get; set; }
    }

    public class FiscalRepresentative
    {
        public TaxNumber FiscalRepresentativeTaxNumber { get; set; }
        public string FiscalRepresentativeName { get; set; }
        public Address FiscalRepresentativeAddress { get; set; }
        public string FiscalRepresentativeBankAccountNumber { get; set; }
    }

    public class InvoiceDetail
    {
        public string InvoiceCategory { get; set; }
        public DateTime InvoiceDeliveryDate { get; set; }
        public DateTime? InvoiceDeliveryPeriodStart { get; set; }
        public DateTime? InvoiceDeliveryPeriodEnd { get; set; }
        public DateTime InvoiceAccountingDeliveryDate { get; set; }
        public bool PeriodicalSettlement { get; set; }
        public bool SmallBusinessIndicator { get; set; }
        public string CurrencyCode { get; set; }
        public decimal ExchangeRate { get; set; }
        public bool SelfBillingIndicator { get; set; }
        public string? PaymentMethod { get; set; }
        public DateTime? PaymentDate { get; set; }
        public bool CashAccountingIndicator { get; set; }
        public string InvoiceAppearance { get; set; }
        public string ElectronicInvoiceHash { get; set; }
        public IEnumerable<AdditionalData> AdditionalInvoiceData { get; set; }
    }

    public class AdditionalData
    {
        public string DataName { get; set; }
        public string DataDescription { get; set; }
        public string DataValue { get; set; }
    }

    public class InvoiceLine
    {
        public string LineNumber { get; set; }
        public LineModificationReference LineModificationReference { get; set; }
        public IEnumerable<string> ReferencesToOtherLines { get; set; }
        public bool AdvanceIndicator { get; set; }
        public IEnumerable<ProductCode> ProductCodes { get; set; }
        public bool LineExpressionIndicator { get; set; }
        public string LineNatureIndicator { get; set; }
        public string LineDescription { get; set; }
        public decimal? Quantity { get; set; }
        public string UnitOfMeasure { get; set; }
        public string UnitOfMeasureOwn { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? UnitPriceHUF { get; set; }
        public DiscountData LineDiscountData { get; set; }
        public LineAmountsNormal LineAmountsNormal { get; set; }
        public bool IntermediatedService { get; set; }
        public AggregateInvoiceLineData AggregateInvoiceLineData { get; set; }
        public NewTransportMean NewTransportMean { get; set; }
        public bool DepositIndicator { get; set; }
        public string MarginSchemeIndicator { get; set; }
        public IEnumerable<string> EkaerIds { get; set; }
        public bool ObligatedForProductFee { get; set; }
        public decimal? GPCExcise { get; set; }
        public DieselOilPurchase DieselOilPurchase { get; set; }
        public bool NetaDeclaration { get; set; }
        public ProductFeeClause ProductFeeClause { get; set; }
        public IEnumerable<ProductFeeData> LineProductFeeContent { get; set; }
        public IEnumerable<AdditionalData> AdditionalLineData { get; set; }
    }

    public class LineModificationReference
    {
        public string LineNumberReference { get; set; }
        public string LineOperation { get; set; }
    }

    public class ProductCode
    {
        public string ProductCodeCategory { get; set; }
        public string Item { get; set; }
        public string ItemElementName { get; set; }
    }

    public class DiscountData
    {
        public string DiscountDescription { get; set; }
        public decimal? DiscountValue { get; set; }
        public decimal? DiscountRate { get; set; }
    }

    public class LineAmountsNormal
    {
        public LineNetAmountData LineNetAmountData { get; set; }
        public VatRate LineVatRate { get; set; }
        public LineVatData LineVatData { get; set; }
        public LineGrossAmountData LineGrossAmountData { get; set; }
    }

    public class LineNetAmountData
    {
        public decimal LineNetAmount { get; set; }
        public decimal LineNetAmountHUF { get; set; }
    }

    public class VatRate
    {
        public string Type { get; set; }
        public string ItemElementName { get; set; }
    }

    public class LineVatData
    {
        public decimal LineVatAmount { get; set; }
        public decimal LineVatAmountHUF { get; set; }
    }

    public class LineGrossAmountData
    {
        public decimal LineGrossAmountNormal { get; set; }
        public decimal LineGrossAmountNormalHUF { get; set; }
    }

    public class AggregateInvoiceLineData
    {
        public decimal? LineExchangeRate { get; set; }
        public DateTime LineDeliveryDate { get; set; }
    }

    public class NewTransportMean
    {
        public string Brand { get; set; }
        public string SerialNum { get; set; }
        public string EngineNum { get; set; }
        public DateTime FirstEntryIntoService { get; set; }
        public object Item { get; set; }
    }

    public class DieselOilPurchase
    {
        public Address PurchaseLocation { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string VehicleRegistrationNumber { get; set; }
        public decimal? DieselOilQuantity { get; set; }
    }

    public class ProductFeeClause
    {
        public CustomerDeclaration CustomerDeclaration { get; set; }
        public ProductFeeTakeoverData ProductFeeTakeoverData { get; set; }
    }

    public class CustomerDeclaration
    {
        public string productStream { get; set; }
        public decimal? productFeeWeight { get; set; }
    }

    public class ProductFeeTakeoverData
    {
        public string takeoverReason { get; set; }
        public decimal? takeoverAmount { get; set; }
    }

    public class ProductFeeData
    {
        public ProductCode ProductFeeCode { get; set; }
        public decimal ProductFeeQuantity { get; set; }
        public string ProductFeeMeasuringUnit { get; set; }
        public decimal ProductFeeRate { get; set; }
        public decimal ProductFeeAmount { get; set; }
    }

    public class ProductFeeSummary
    {
        public string ProductFeeOperation { get; set; }
        public IEnumerable<ProductFeeData> ProductFeeData { get; set; }
        public decimal ProductChargeSum { get; set; }
        public PaymentEvidenceDocumentData PaymentEvidenceDocumentData { get; set; }
    }

    public class PaymentEvidenceDocumentData
    {
        public string EvidenceDocumentNo { get; set; }
        public DateTime EvidenceDocumentDate { get; set; }
        public string ObligatedName { get; set; }
        public Address ObligatedAddress { get; set; }
        public TaxNumber ObligatedTaxNumber { get; set; }
    }

    public class InvoiceSummary
    {
        public IEnumerable<SummaryNormal> SummaryNormal { get; set; }
        public IEnumerable<SummarySimplified> SummarySimplified { get; set; }
        public SummaryGrossData SummaryGrossData { get; set; }
    }

    public class SummaryNormal
    {
        public IEnumerable<SummaryByVatRate> SummaryByVatRate { get; set; }
        public decimal InvoiceNetAmount { get; set; }
        public decimal InvoiceNetAmountHUF { get; set; }
        public decimal InvoiceVatAmount { get; set; }
        public decimal InvoiceVatAmountHUF { get; set; }
    }

    public class SummaryByVatRate
    {
        public VatRate VatRate { get; set; }
        public VatRateNetData VatRateNetData { get; set; }
        public VatRateVatData VatRateVatData { get; set; }
        public VatRateGrossData VatRateGrossData { get; set; }
    }

    public class VatRateNetData
    {
        public decimal VatRateNetAmount { get; set; }
        public decimal VatRateNetAmountHUF { get; set; }
    }

    public class VatRateVatData
    {
        public decimal VatRateVatAmount { get; set; }
        public decimal VatRateVatAmountHUF { get; set; }
    }

    public class VatRateGrossData
    {
        public decimal VatRateGrossAmount { get; set; }
        public decimal VatRateGrossAmountHUF { get; set; }
    }

    public class SummarySimplified 
    {
        public decimal VatContent { get; set; }
        public decimal VatContentGrossAmount { get; set; }
        public decimal VatContentGrossAmountHUF { get; set; }
    }

    public class SummaryGrossData
    {
        public decimal InvoiceGrossAmount { get; set; }
        public decimal InvoiceGrossAmountHUF { get; set; }
    }
}