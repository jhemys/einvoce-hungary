using AutoMapper;
using eInvoice.Hungary.Domain.AggregatesModel.InvoiceDataAggregate;

namespace eInvoice.Hungary.Api.Models
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<InvoiceDataModel, InvoiceData>();
            CreateMap<InvoiceMainDataModel, InvoiceMainData>();
            CreateMap<InvoiceInformationModel, InvoiceInformartion>();
            CreateMap<InvoiceReferenceModel, InvoiceReference>();
            CreateMap<InvoiceHeadModel, InvoiceHead>();
            CreateMap<InvoiceLineModel, InvoiceLine>();
            CreateMap<ProductFeeSummaryModel, ProductFeeSummary>();
            CreateMap<InvoiceSummaryModel, InvoiceSummary>();
            CreateMap<SupplierInfoModel, SupplierInfo>();
            CreateMap<CustomerInfoModel, CustomerInfo>();
            CreateMap<FiscalRepresentativeModel, FiscalRepresentative>();
            CreateMap<InvoiceDetailModel, InvoiceDetail>();
            CreateMap<TaxNumberModel, TaxNumber>();
            CreateMap<AddressModel, Address>();
            CreateMap<AdditionalDataModel, AdditionalData>();
            CreateMap<LineModificationReferenceModel, LineModificationReference>();
            CreateMap<ProductCodeModel, ProductCode>();
            CreateMap<DiscountDataModel, DiscountData>();
            CreateMap<LineAmountsNormalModel, LineAmountsNormal>();
            CreateMap<AggregateInvoiceLineDataModel, AggregateInvoiceLineData>();
            CreateMap<NewTransportMeanModel, NewTransportMean>();
            CreateMap<DieselOilPurchaseModel, DieselOilPurchase>();
            CreateMap<ProductFeeClauseModel, ProductFeeClause>();
            CreateMap<ProductFeeDataModel, ProductFeeData>();
            CreateMap<LineNetAmountDataModel, LineNetAmountData>();
            CreateMap<VatRateModel, VatRate>();
            CreateMap<LineVatDataModel, LineVatData>();
            CreateMap<LineGrossAmountDataModel, LineGrossAmountData>();
            CreateMap<CustomerDeclarationModel, CustomerDeclaration>();
            CreateMap<ProductFeeTakeoverDataModel, ProductFeeTakeoverData>();
            CreateMap<PaymentEvidenceDocumentDataModel, PaymentEvidenceDocumentData>();
            CreateMap<SummaryNormalModel, SummaryNormal>();
            CreateMap<SummarySimplifiedModel, SummarySimplified>();
            CreateMap<SummaryGrossDataModel, SummaryGrossData>();
            CreateMap<SummaryByVatRateModel, SummaryByVatRate>();
            CreateMap<VatRateNetDataModel, VatRateNetData>();
            CreateMap<VatRateVatDataModel, VatRateVatData>();
            CreateMap<VatRateGrossDataModel, VatRateGrossData>();
        }
    }
}
