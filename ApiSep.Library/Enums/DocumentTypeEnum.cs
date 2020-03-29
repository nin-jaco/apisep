using System.ComponentModel;
using System.Runtime.Serialization;
using ApiSep.Library.Attributes;

namespace ApiSep.Library.Enums
{
    [Help(@"string documentType = DocumentType.Description();"), DataContract(Namespace = "ApiSep.Library.Enums", Name = "DocumentTypeEnum")]
    public enum DocumentTypeEnum
    {
        [Description("Quote"), ShortDescription("Quotation"), XslName("quote"), EnumMember(Value = "Quote")]
        Quote = 0,
        [Description("Offer to Purchase"), ShortDescription("OTP"), XslName("otp"), EnumMember(Value = "Otp")]
        Otp = 1,
        [Description("Company Details"), ShortDescription("CompanyDetails"), XslName("Company Details"), EnumMember(Value = "CompanyDetails")]
        CompanyDetails = 2,
        [Description("Customer Acceptance Form"), ShortDescription("CustomerAcceptanceForm"), XslName("Customer Acceptance Form"), EnumMember(Value = "CustomerAcceptanceForm")]
        CustomerAcceptanceForm = 3,
        [Description("Driver Details"), ShortDescription("DriverDetails"), XslName("Driver Details"), EnumMember(Value = "DriverDetails")]
        DriverDetails = 4,
        [Description("Trade-in Valuation"), ShortDescription("TradeInValuation"), XslName("Trade-in Valuation"), EnumMember(Value = "TradeInValuation")]
        TradeInValuation = 5,
        [Description("Available Options"), ShortDescription("AvailableOptions"), XslName("Available Options"), EnumMember(Value = "AvailableOptions")]
        AvailableOptions = 6,
        [Description("Declaration by Seller"), ShortDescription("DeclarationBySeller"), XslName("Declaration By Seller"), EnumMember(Value = "DeclarationBySeller")]
        DeclarationBySeller = 7,
        [Description("Delivery Document"), ShortDescription("DeliveryDocument"), XslName("Delivery Document"), EnumMember(Value = "DeliveryDocument")]
        DeliveryDocument = 8,
        [Description("Kit Card"), ShortDescription("KITCard"), XslName("KIT Card"), EnumMember(Value = "KitCard")]
        KitCard = 9,
        [Description("Used Car Clearance Form"), ShortDescription("UsedCarClearanceForm"), XslName("Used Car Clearance Form"), EnumMember(Value = "UsedCarClearanceForm")]
        UsedCarClearanceForm = 10,
        [Description("VAT264"), ShortDescription("VAT264"), XslName("VAT264"), EnumMember(Value = "Vat264")]
        Vat264 = 11,
        [Description("None in this session"), ShortDescription("None"), XslName(""), EnumMember(Value = "None")]
        None = 12,
        [Description("Afp Warranty"), ShortDescription("AfpWarranty"), XslName(""), EnumMember(Value = "AfpWarranty")]
        AfpWarranty = 13,
        [Description("Audi Warranty Terms"), ShortDescription("AudiWarrantyTerms"), XslName(""), EnumMember(Value = "AudiWarrantyTerms")]
        AudiWarrantyTerms = 14,
        [Description("Audi Sales Handover Check Sheet"), ShortDescription("AudiSalesHandoverCheckSheet"), XslName(""), EnumMember(Value = "AudiSalesHandoverCheckSheet")]
        AudiSalesHandoverChecklist= 15,
        [Description("BDI Template"), ShortDescription("BDITemplate"), XslName(""), EnumMember(Value = "BDITemplate")]
        BdiTemplate = 16,
        [Description("Delivery Note"), ShortDescription("DeliveryNote"), XslName(""), EnumMember(Value = "DeliveryNote")]
        DeliveryNote = 17,
        [Description("Needs Analysis"), ShortDescription("NeedsAnalysis"), XslName(""), EnumMember(Value = "NeedsAnalysis")]
        NeedsAnalysis = 18,
        [Description("Vehicle Handover Checklist"), ShortDescription("VehicleHandoverChecklist"), XslName(""), EnumMember(Value = "VehicleHandoverChecklist")]
        VehicleHandoverChecklist = 19,
        [Description("VW BDI Checklist"), ShortDescription("VwBdiChecklist"), XslName(""), EnumMember(Value = "VwBdiChecklist")]
        VwBdiChecklist = 20,
        [Description("VW BDI Mastercar Checklist"), ShortDescription("VwBdiChecklistMastercar"), XslName(""), EnumMember(Value = "VwBdiChecklistMastercar")]
        VwBdiChecklistMastercar = 21,
        [Description("VW Final Inspection and Delivery Note"), ShortDescription("VWFinalInspectionAndDeliveryNote"), XslName(""), EnumMember(Value = "VWFinalInspectionAndDeliveryNote")]
        VwFinalInspectionAndDeliveryNote = 22,
        [Description("VW Handover Checksheet Smileys"), ShortDescription("VWHandoverChecksheetSmileys"), XslName(""), EnumMember(Value = "VWHandoverChecksheetSmileys")]
        VwHandoverChecksheetSmileys = 23,
        [Description("VW Policy Decline"), ShortDescription("VWPolicyDecline"), XslName(""), EnumMember(Value = "VWPolicyDecline")]
        VwPolicyDecline = 24,
        [Description("VW Recon Black"), ShortDescription("VwReconBlack"), XslName(""), EnumMember(Value = "VwReconBlack")]
        VwReconBlack = 25,
        [Description("VW Sales Executive Vehicle Handover Checklist"), ShortDescription("VwSalesExecutiveVehicleHandoverChecklist"), XslName(""), EnumMember(Value = "VwSalesExecutiveVehicleHandoverChecklist")]
        VwSalesExecutiveVehicleHandoverChecklist = 26,
        [Description("VW Salesman Deal File Checklist"), ShortDescription("VwSalesmanDealFileChecklist"), XslName(""), EnumMember(Value = "VwSalesmanDealFileChecklist")]
        VwSalesmanDealFileChecklist = 27,
        [Description("VW Used Vehicle Clearance"), ShortDescription("VwUsedVehicleClearance"), XslName(""), EnumMember(Value = "VwUsedVehicleClearance")]
        VwUsedVehicleClearance = 28,
        [Description("VW VAT Declaration"), ShortDescription("VwVatDeclaration"), XslName(""), EnumMember(Value = "VwVatDeclaration")]
        VwVatDeclaration = 29,
        [Description("VW Vehicle Delivery Document"), ShortDescription("VwVehicleDeliveryDocument"), XslName(""), EnumMember(Value = "VwVehicleDeliveryDocument")]
        VwVehicleDeliveryDocument = 30,
        [Description("VW Recon Sheet"), ShortDescription("VwReconSheet"), XslName(""), EnumMember(Value = "VwReconSheet")]
        VwReconSheet = 31,
        [Description("VW Follow Up Call"), ShortDescription("VwFollowUpCall"), XslName(""), EnumMember(Value = "VwFollowUpCall")]
        VwFollowUpCall = 32,
        [Description("VW Authorize Paper"), ShortDescription("VwAuthorizePaper"), XslName(""), EnumMember(Value = "VwAuthorizePaper")]
        VwAuthorizePaper = 33,
        [Description("VW Acknowledgement of Liability"), ShortDescription("VwAcknowledgementOfLiability"), XslName(""), EnumMember(Value = "VwAcknowledgementOfLiability")]
        VwAcknowledgementOfLiability = 34,
    }
}
