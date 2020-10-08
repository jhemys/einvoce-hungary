using System;
using System.Collections.Generic;

namespace eInvoice.Hungary.Api.Models
{
    public class InvoiceDataModel
    {
        public Guid Guid { get; set; }
        public int InvoiceId { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceIssueDate { get; set; }
        public InvoiceMainDataModel InvoiceMainData { get; set; }
    }

    public class InvoiceMainDataModel
    {
        public IEnumerable<InvoiceInformationModel> Invoices { get; set; }

    }

    public class InvoiceInformationModel
    {
        public InvoiceReferenceModel InvoiceReference { get; set; }
        public InvoiceHeadModel InvoiceHead { get; set; }
        public IEnumerable<InvoiceLineModel> InvoiceLines { get; set; }
        public IEnumerable<ProductFeeSummaryModel> ProductFeeSummaries { get; set; }
        public InvoiceSummaryModel InvoiceSummary { get; set; }
    }

    public class InvoiceReferenceModel
    {
        public string OriginalInvoiceNumber { get; set; }
        public bool ModifyWithoutMaster { get; set; }
        public int ModificationIndex { get; set; }
    }

    public class InvoiceHeadModel
    {
        public SupplierInfoModel SupplierInfo { get; set; }
        public CustomerInfoModel CustomerInfo { get; set; }
        public FiscalRepresentativeModel FiscalRepresentativeInfo { get; set; }
        public InvoiceDetailModel InvoiceDetail { get; set; }
    }

    public class SupplierInfoModel
    {
        public TaxNumberModel SupplierTaxNumber { get; set; }
        public TaxNumberModel GroupMemberTaxNumber { get; set; }
        public string CommunityVatNumber { get; set; }
        public string SupplierName { get; set; }
        public AddressModel SupplierAddress { get; set; }
        public string SupplierBankAccountNumber { get; set; }
        public bool IndividualExemption { get; set; }
        public string ExciseLicenceNum { get; set; }
    }


    public class CustomerInfoModel
    {
        public TaxNumberModel CustomerTaxNumber { get; set; }
        public TaxNumberModel GroupMemberTaxNumber { get; set; }
        public string CommunityVatNumber { get; set; }
        public string ThirdStateTaxId { get; set; }
        public string CustomerName { get; set; }
        public AddressModel CustomerAddress { get; set; }
        public string CustomerBankAccountNumber { get; set; }
    }

    public class TaxNumberModel
    {
        public string TaxpayerId { get; set; }
        public string VatCode { get; set; }
        public string CountyCode { get; set; }
    }

    public class AddressModel
    {
        public string CountryCode { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string AdditionalAddressDetail { get; set; }
    }

    public class FiscalRepresentativeModel
    {
        public TaxNumberModel FiscalRepresentativeTaxNumber { get; set; }
        public string FiscalRepresentativeName { get; set; }
        public AddressModel FiscalRepresentativeAddress { get; set; }
        public string FiscalRepresentativeBankAccountNumber { get; set; }
    }

    public class InvoiceDetailModel
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
        public IEnumerable<AdditionalDataModel> AdditionalInvoiceData { get; set; }
    }

    public class AdditionalDataModel
    {
        public string DataName { get; set; }
        public string DataDescription { get; set; }
        public string DataValue { get; set; }
    }

    public class InvoiceLineModel
    {
        public string LineNumber { get; set; }
        public LineModificationReferenceModel LineModificationReference { get; set; }
        public IEnumerable<string> ReferencesToOtherLines { get; set; }
        public bool AdvanceIndicator { get; set; }
        public IEnumerable<ProductCodeModel> ProductCodes { get; set; }
        public bool LineExpressionIndicator { get; set; }
        public string LineNatureIndicator { get; set; }
        public string LineDescription { get; set; }
        public decimal? Quantity { get; set; }
        public string UnitOfMeasure { get; set; }
        public string UnitOfMeasureOwn { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? UnitPriceHUF { get; set; }
        public DiscountDataModel LineDiscountData { get; set; }
        public LineAmountsNormalModel LineAmountsNormal { get; set; }
        public bool IntermediatedService { get; set; }
        public AggregateInvoiceLineDataModel AggregateInvoiceLineData { get; set; }
        public NewTransportMeanModel NewTransportMean { get; set; }
        public bool DepositIndicator { get; set; }
        public string MarginSchemeIndicator { get; set; }
        public IEnumerable<string> EkaerIds { get; set; }
        public bool ObligatedForProductFee { get; set; }
        public decimal? GPCExcise { get; set; }
        public DieselOilPurchaseModel DieselOilPurchase { get; set; }
        public bool NetaDeclaration { get; set; }
        public ProductFeeClauseModel ProductFeeClause { get; set; }
        public IEnumerable<ProductFeeDataModel> LineProductFeeContent { get; set; }
        public IEnumerable<AdditionalDataModel> AdditionalLineData { get; set; }
    }

    public class LineModificationReferenceModel
    {
        public string LineNumberReference { get; set; }
        public string LineOperation { get; set; }
    }

    public class ProductCodeModel
    {
        public string ProductCodeCategory { get; set; }
        public string Item { get; set; }
        public string ItemElementName { get; set; }
    }

    public class DiscountDataModel
    {
        public string DiscountDescription { get; set; }
        public decimal? DiscountValue { get; set; }
        public decimal? DiscountRate { get; set; }
    }

    public class LineAmountsNormalModel
    {
        public LineNetAmountDataModel LineNetAmountData { get; set; }
        public VatRateModel LineVatRate { get; set; }
        public LineVatDataModel LineVatData { get; set; }
        public LineGrossAmountDataModel LineGrossAmountData { get; set; }
    }

    public class LineNetAmountDataModel
    {
        public decimal LineNetAmount { get; set; }
        public decimal LineNetAmountHUF { get; set; }
    }

    public class VatRateModel
    {
        public string Type { get; set; }
        public string ItemElementName { get; set; }
    }

    public class LineVatDataModel
    {
        public decimal LineVatAmount { get; set; }
        public decimal LineVatAmountHUF { get; set; }
    }

    public class LineGrossAmountDataModel
    {
        public decimal LineGrossAmountNormal { get; set; }
        public decimal LineGrossAmountNormalHUF { get; set; }
    }

    public class AggregateInvoiceLineDataModel
    {
        public decimal? LineExchangeRate { get; set; }
        public DateTime LineDeliveryDate { get; set; }
    }

    public class NewTransportMeanModel
    {
        public string Brand { get; set; }
        public string SerialNum { get; set; }
        public string EngineNum { get; set; }
        public DateTime FirstEntryIntoService { get; set; }
        public object Item { get; set; }
    }

    public class DieselOilPurchaseModel
    {
        public AddressModel PurchaseLocation { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string VehicleRegistrationNumber { get; set; }
        public decimal? DieselOilQuantity { get; set; }
    }

    public class ProductFeeClauseModel
    {
        public CustomerDeclarationModel CustomerDeclaration { get; set; }
        public ProductFeeTakeoverDataModel ProductFeeTakeoverData { get; set; }
    }

    public class CustomerDeclarationModel
    {
        public string productStream { get; set; }
        public decimal? productFeeWeight { get; set; }
    }

    public class ProductFeeTakeoverDataModel
    {
        public string takeoverReason { get; set; }
        public decimal? takeoverAmount { get; set; }
    }

    public class ProductFeeDataModel
    {
        public ProductCodeModel ProductFeeCode { get; set; }
        public decimal ProductFeeQuantity { get; set; }
        public string ProductFeeMeasuringUnit { get; set; }
        public decimal ProductFeeRate { get; set; }
        public decimal ProductFeeAmount { get; set; }
    }

    public class ProductFeeSummaryModel
    {
        public string ProductFeeOperation { get; set; }
        public IEnumerable<ProductFeeDataModel> ProductFeeData { get; set; }
        public decimal ProductChargeSum { get; set; }
        public PaymentEvidenceDocumentDataModel PaymentEvidenceDocumentData { get; set; }
    }

    public class PaymentEvidenceDocumentDataModel
    {
        public string EvidenceDocumentNo { get; set; }
        public DateTime EvidenceDocumentDate { get; set; }
        public string ObligatedName { get; set; }
        public AddressModel ObligatedAddress { get; set; }
        public TaxNumberModel ObligatedTaxNumber { get; set; }
    }

    public class InvoiceSummaryModel
    {
        public IEnumerable<SummaryNormalModel> SummaryNormal { get; set; }
        public IEnumerable<SummarySimplifiedModel> SummarySimplified { get; set; }
        public SummaryGrossDataModel SummaryGrossData { get; set; }
    }

    public class SummaryNormalModel
    {
        public IEnumerable<SummaryByVatRateModel> SummaryByVatRate { get; set; }
        public decimal InvoiceNetAmount { get; set; }
        public decimal InvoiceNetAmountHUF { get; set; }
        public decimal InvoiceVatAmount { get; set; }
        public decimal InvoiceVatAmountHUF { get; set; }
    }

    public class SummaryByVatRateModel
    {
        public VatRateModel VatRate { get; set; }
        public VatRateNetDataModel VatRateNetData { get; set; }
        public VatRateVatDataModel VatRateVatData { get; set; }
        public VatRateGrossDataModel VatRateGrossData { get; set; }
    }

    public class VatRateNetDataModel
    {
        public decimal VatRateNetAmount { get; set; }
        public decimal VatRateNetAmountHUF { get; set; }
    }

    public class VatRateVatDataModel
    {
        public decimal VatRateVatAmount { get; set; }
        public decimal VatRateVatAmountHUF { get; set; }
    }

    public class VatRateGrossDataModel
    {
        public decimal VatRateGrossAmount { get; set; }
        public decimal VatRateGrossAmountHUF { get; set; }
    }

    public class SummarySimplifiedModel
    {
        public decimal VatContent { get; set; }
        public decimal VatContentGrossAmount { get; set; }
        public decimal VatContentGrossAmountHUF { get; set; }
    }

    public class SummaryGrossDataModel
    {
        public decimal InvoiceGrossAmount { get; set; }
        public decimal InvoiceGrossAmountHUF { get; set; }
    }
}
