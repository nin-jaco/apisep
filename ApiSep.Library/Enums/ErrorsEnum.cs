using System.ComponentModel;
using System.Runtime.Serialization;
using ApiSep.Library.Attributes;

namespace ApiSep.Library.Enums
{
    [Help(@"string contactAction = ContactActionsEnum.Description();"), DataContract(Namespace = "ApiSep.Library.Enums", Name = "ErrorsEnum")]
    public enum ErrorsEnum
    {
        #region Login
        //todo: add the friendly error messages for the login and just display the property
        [Description("Invalid Dealer-Code and Dealer-Name combination."), FriendlyErrorMessage("Invalid dealer-id and dealer-code combination."), EnumMember(Value = "InvalidDealerCodeAndNameCombination")]
        InvalidDealerCodeAndNameCombination = 0,
        [Description("No such user at the dealer."), FriendlyErrorMessage("The user does not exist."), EnumMember(Value = "NoSuchUserAtDealer")]
        NoSuchUserAtDealer = 1,
        [Description("User has been deactivated."), FriendlyErrorMessage("The user has been deactivated."), EnumMember(Value = "UserInactive")]
        UserInactive = 2,
        [Description("User has been deleted."), FriendlyErrorMessage("The user has been deleted."), EnumMember(Value = "UserDeleted")]
        UserDeleted = 3,
        [Description("Password is incorrect."), FriendlyErrorMessage("The password is incorrect."), EnumMember(Value = "InvalidPassword")]
        InvalidPassword = 4,
        #endregion

        #region quote
        [Description("Cannot find quote for id."), FriendlyErrorMessage("Cannot find a quote for this Id."), EnumMember(Value = "QuoteDoesNotExist")]
        QuoteDoesNotExist = 5,
        [Description("Exception Thrown."), FriendlyErrorMessage("An exception was encountered during this request. The Error has been logged and forwarded to the developers for attention."), EnumMember(Value = "ExceptionEncountered")]
        ExceptionEncountered = 6,
        [Description("Data Entity Validation Exception."), FriendlyErrorMessage("An attempt was made to save invalid data. The Error has been logged and forwarded to the developers for attention."), EnumMember(Value = "DataValidationException")]
        DataValidationException = 7,
        [Description("Quote was already submitted to F and I."), FriendlyErrorMessage("This Quote was already submitted to F and I and cannot be processed."), EnumMember(Value = "QuotePreviouslySubmittedToFAndI")]
        QuotePreviouslySubmittedToFAndI = 8,
        [Description("There is not an active finance person at the dealership."), FriendlyErrorMessage("We were unable to find an active F and I person at your dealership, in the database."), EnumMember(Value = "NoFinancePersonAtDealership")]
        NoFinancePersonAtDealership = 9,
        [Description("OTP has already been signed"), FriendlyErrorMessage("This OTP has already been signed."), EnumMember(Value = "OtpHasAlreadyBeenSigned")]
        OtpHasAlreadyBeenSigned = 10,
        [Description("Vehicle not in stock"), FriendlyErrorMessage("This vehicle {0} has not been marked as arrived at the dealership or has already previously been delivered as New."), EnumMember(Value = "VehicleNotInStock")]
        VehicleNotInStock = 11,
        [Description("DLRAAC Date Not Valid"), FriendlyErrorMessage("DLRAAC Date in MTV Stock table is not valid."), EnumMember(Value = "DlraacDateNotValid")]
        DlraacDateNotValid = 12,
        [Description("The retail submitter could not submit due to validation errors."), FriendlyErrorMessage("The retail submitter encountered errors, please correct these before submitting again."), EnumMember(Value = "RetailSubmitterValidationErrors")]
        RetailSubmitterValidationErrors = 13,
        [Description("The OTP cannot be submitted due to missing fields."), FriendlyErrorMessage("The OTP cannot be submitted due to missing fields.  Please provide the missing information and submit again."), EnumMember(Value = "OtpCannotBeSubmittedDueToMissingFields")]
        OtpCannotBeSubmittedDueToMissingFields = 14,
        #endregion Quote

        #region Seriti
        [Description("The response object was null."), FriendlyErrorMessage("The request to Seriti did not return a response."), EnumMember(Value = "NoSeritiResponse")]
        NoSeritiResponse = 15,
        [Description("200 Success but some fields were ignored"), FriendlyErrorMessage("Some mandatory fields are empty."), EnumMember(Value = "SeritiFieldEmpty")]
        SeritiFieldEmpty = 16,
        [Description("300 Data failure"), FriendlyErrorMessage("Seriti encountered a data failure."), EnumMember(Value = "SeritiDataFailure")]
        SeritiDataFailure = 17,
        [Description("400 Authentication failure"), FriendlyErrorMessage("Seriti authentication failed. Credentials CompanyCode and/or CompanyPassword is incorrect"), EnumMember(Value = "SeritiAuthenticationFailure")]
        SeritiAuthenticationFailure = 18,
        [Description("410 Authorisation failure"), FriendlyErrorMessage("You are not authorized to execute this request with Seriti"), EnumMember(Value = "SeritiAuthorisationFailure")]
        SeritiAuthorisationFailure = 19,
        [Description("420 Not authorised to view the policy"), FriendlyErrorMessage("You are not authorized to to view this policy"), EnumMember(Value = "SeritiNotAllowedToViewPolicy")]
        SeritiNotAllowedToViewPolicy = 20,
        [Description("500 System failure"), FriendlyErrorMessage("Seriti encountered a system failure"), EnumMember(Value = "SeritiSystemFailure")]
        SeritiSystemFailure = 21,
        #endregion

        #region SAP
        [Description("USE_SAP_COMPANIES_LOOKUP is no or missing"), FriendlyErrorMessage("USE_SAP_COMPANIES_LOOKUP in PARAMS_PRO is disabled or does not exist."), EnumMember(Value = "UseSapCompanyLookupMissing")]
        UseSapCompanyLookupMissing = 22,
        [Description("COMPANIES_LOOKUP_PAGE is missing"), FriendlyErrorMessage("COMPANIES_LOOKUP_PAGE in PARAMS_PRO does not exist or has an empty value."), EnumMember(Value = "SapCompanyLookupPageMissing")]
        SapCompanyLookupPageMissing = 23,
        [Description("SAP Username is missing"), FriendlyErrorMessage("SAP_USERNAME in PARAMS_PRO does not exist or has an empty value."), EnumMember(Value = "SapUsernameMissing")]
        SapUsernameMissing = 24,
        [Description("SAP Password is missing"), FriendlyErrorMessage("SAP_PASSWORD in PARAMS_PRO does not exist or has an empty value."), EnumMember(Value = "SapPasswordMissing")]
        SapPasswordMissing = 25,
        [Description("SAP returned no results"), FriendlyErrorMessage("SAP returned no results."), EnumMember(Value = "SapNoResultsReturned")]
        SapNoResultsReturned = 26,
        [Description("USE_SAP_STOCK_LOOKUP is no or missing"), FriendlyErrorMessage("USE_SAP_STOCK_LOOKUP in PARAMS_PRO is disabled or does not exist."), EnumMember(Value = "UseSapStockLookupMissing")]
        UseSapStockLookupMissing = 27,
        #endregion

        #region General
        [Description("Problem Saving Data Object"), FriendlyErrorMessage("The system could not update the object in the database."), EnumMember(Value = "ProblemSavingDataObject")]
        ProblemSavingDataObject = 28,
        [Description("Cannot Connect To Remote Server"), FriendlyErrorMessage("Cannot Connect To Remote Server."), EnumMember(Value = "CannotConnectToRemoteServer")]
        CannotConnectToRemoteServer = 77,
        #endregion

        #region SignFlowSignatureApi
        [Description("Signflow Login failed"), FriendlyErrorMessage("Login Failed to SignFlow."), EnumMember(Value = "SignFlowLoginFailed")]
        SignFlowLoginFailed = 29,
        [Description("Could not get document details"), FriendlyErrorMessage("Could not get document field settings."), EnumMember(Value = "SignFlowFieldSettingsNotFound")]
        SignFlowFieldSettingsNotFound = 30,
        [Description("Could not prepare document"), FriendlyErrorMessage("Could not prepare document for signing."), EnumMember(Value = "SignFlowCouldNotPrepDocument")]
        SignFlowCouldNotPrepDocument = 31,
        [Description("Could not start workflow"), FriendlyErrorMessage("Could not start SignFlow workflow."), EnumMember(Value = "SignFlowWorkflowNotStarted")]
        SignFlowWorkflowNotStarted = 32,
        [Description("Could not create workflow"), FriendlyErrorMessage("Could not create SignFlow workflow."), EnumMember(Value = "SignFlowCouldNotCreateWorkflow")]
        SignFlowCouldNotCreateWorkflow = 33,
        [Description("Could not create workflow step"), FriendlyErrorMessage("Could not create SignFlow workflow step."), EnumMember(Value = "SignFlowCouldNotCreateWorkflowStep")]
        SignFlowCouldNotCreateWorkflowStep = 34,
        [Description("Could not fetch document"), FriendlyErrorMessage("Could not retrieve the document from the Signflow database."), EnumMember(Value = "SignFlowCouldNotReturnDocument")]
        SignFlowCouldNotReturnDocument = 35,
        [Description("Could not reach SignFlow Server"), FriendlyErrorMessage("SignFlow Service is blocked on the network firewall."), EnumMember(Value = "SignFlowBlocked")]
        SignFlowBlocked = 76,
        #endregion

        #region Capitalized sales
        [Description("SAP Cancel Capitalized Sale URL missing"), FriendlyErrorMessage("Cannot find the SAP Cancel Capitalized Sale URL in the database."), EnumMember(Value = "SapCancelCapitalizedSaleUrlMissing")]
        SapCancelCapitalizedSaleUrlMissing = 36,
        [Description("Capitalized Sale Item Missing"), FriendlyErrorMessage("Cannot find the Capitalized Sale Item with ID {0}."), EnumMember(Value = "CapitalizedSaleItemMissing")]
        CapitalizedSaleItemMissing = 37,
        #endregion

        #region Retail Submission Common
        [Description("SAP Validation Failed"), FriendlyErrorMessage("Submission was unsuccessful. Please correct the validation errors and try again."), EnumMember(Value = "SapValidationFailed")]
        SapValidationFailed = 38,
        [Description("No entry for this VIN in the Commercial Mod Table"), FriendlyErrorMessage("Submission was unsuccessful.  This is a Commercial Vehicle No entry for this VIN in the Commercial Mod Table."), EnumMember(Value = "CommercialModMissing")]
        CommercialModMissing = 39,
        #endregion

        #region Contacts
        [Description("A contact already exists for Id"), FriendlyErrorMessage("A contact already exists for Id for this dealer."), EnumMember(Value = "ContactAlreadyExistsForId")]
        ContactAlreadyExistsForId = 40,
        [Description("A contact already exists for Mobile"), FriendlyErrorMessage("A contact already exists with this mobile number for this dealer."), EnumMember(Value = "ContactAlreadyExistsForMobile")]
        ContactAlreadyExistsForMobile = 41,
        [Description("A problem occurred while creating a Contact for this Lead"), FriendlyErrorMessage("A problem occurred while creating a Contact for this Lead."), EnumMember(Value = "CouldNotConvertLeadToContact")]
        CouldNotConvertLeadToContact = 42,
        [Description("A problem occurred while linking the contact to the user"), FriendlyErrorMessage("The contact has been created. However, a problem occurred while linking the contact to the user."), EnumMember(Value = "CouldNotCreateContactUser")]
        CouldNotCreateContactUser = 43,
        #endregion

        #region LicenseDiskDecoder
        [Description("License Disk Decoder Login Failed"), FriendlyErrorMessage("Login Failed to the License Disk Decoder."), EnumMember(Value = "LicenseDiskDecoderLoginFailed")]
        LicenseDiskDecoderLoginFailed = 44,
        [Description("License Disk decoding failed"), FriendlyErrorMessage("License Disk decoding failed."), EnumMember(Value = "LicenseDiskDecodingFailed")]
        LicenseDiskDecodingFailed = 45,
        #endregion

        #region LicenseCardDecoder
        [Description("License Card Decoder Login Failed"), FriendlyErrorMessage("Login Failed to the License Card Decoder."), EnumMember(Value = "LicenseCardDecoderLoginFailed")]
        LicenseCardDecoderLoginFailed = 46,
        [Description("License Card decoding failed"), FriendlyErrorMessage("License Card decoding failed."), EnumMember(Value = "LicenseCardDecodingFailed")]
        LicenseCardDecodingFailed = 47,
        [Description("License Card Decoder Cannot Connect to Service"), FriendlyErrorMessage("License Card Decoder Cannot Connect to Service."), EnumMember(Value = "LicenseCardDecoderCannotConnectToService")]
        LicenseCardDecoderCannotConnectToService = 48,
        #endregion

        #region WhatsApp
        [Description("WhatsAppApi Authentication Failure"), FriendlyErrorMessage("403: Cannot Authenticate on WhatsApp."), EnumMember(Value = "WhatsAppAuthenticationFailed")]
        WhatsAppAuthenticationFailed = 49,
        [Description("WhatsAppApi Parameters Validation Failure"), FriendlyErrorMessage("400: One or more fields submitted have validation errors."), EnumMember(Value = "WhatsAppParametersValidationFailed")]
        WhatsAppParametersValidationFailed = 50,
        [Description("WhatsAppApi Threw Custom Error"), FriendlyErrorMessage("WhatsAppApi threw a custom error."), EnumMember(Value = "WhatsAppReturnedCustomError")]
        WhatsAppReturnedCustomError = 51,
        [Description("WhatsApp Credentials Missing"), FriendlyErrorMessage("WhatsApp Credential Parameters Missing in Database."), EnumMember(Value = "WhatsAppCredentialsMissing")]
        WhatsAppCredentialsMissing = 52,
        [Description("Dealer Settings does not allow the sending of WhatsApp Messages."), FriendlyErrorMessage("WhatsApp Settings does not allow the dealer to send WhatsApp Messages."), EnumMember(Value = "WhatsAppNotAllowed")]
        WhatsAppNotAllowed = 53,
        [Description("Cannot reach WhatsAppApi External Service."), FriendlyErrorMessage("WhatsAppApi Service is blocked on the network firewall."), EnumMember(Value = "WhatsAppBlocked")]
        WhatsAppBlocked = 75,
        #endregion

        #region SignFlowEventReceiver
        [Description("No Action Error"), FriendlyErrorMessage("SignFlow Event Receiver threw a Non Action Error."), EnumMember(Value = "SignFlowEventReceiverNoActionError")]
        SignFlowEventReceiverNoActionError = 54,
        [Description("SignFlowSecret Missing Error"), FriendlyErrorMessage("SignFlowSecret missing from Application Settings."), EnumMember(Value = "SignFlowEventReceiverSecretMissingError")]
        SignFlowEventReceiverSecretMissingError = 55,
        [Description("SignFlow Event Receiver Access Denied"), FriendlyErrorMessage("SignFlow Event Receiver Access Denied."), EnumMember(Value = "SignFlowEventReceiverAccessDenied")]
        SignFlowEventReceiverAccessDenied = 56,
        #endregion

        #region Email
        [Description("HasHostedExchangeYN Param Missing"), FriendlyErrorMessage("HasHostedExchangeYN parameter is missing in database."), EnumMember(Value = "HasHostedExchangeYnParamMissing")]
        HasHostedExchangeYnParamMissing = 57,
        [Description("Smtp Url Param Missing"), FriendlyErrorMessage("SMTP Host Name parameter is missing in database."), EnumMember(Value = "SmtpUrlParamMissing")]
        SmtpUrlParamMissing = 58,
        [Description("Smtp Port Param Missing"), FriendlyErrorMessage("SMTP Port parameter is missing in database."), EnumMember(Value = "SmtpPortParamMissing")]
        SmtpPortParamMissing = 59,
        #endregion

        #region Automate
        [Description("Integrate with DMS Param Missing"), FriendlyErrorMessage("Integrate with DMS is missing in database."), EnumMember(Value = "IntegrateWithDmsParamMissing")]
        IntegrateWithDmsParamMissing = 60,
        [Description("Set to NOT Integrate with DMS"), FriendlyErrorMessage("The system is set not to integrate with DMS."), EnumMember(Value = "IntegrateWithDmsParamSetToNo")]
        IntegrateWithDmsParamSetToNo = 61,
        [Description("DMS URL is missing"), FriendlyErrorMessage("The DMS URL is not specified in the database."), EnumMember(Value = "DmsUrlMissing")]
        DmsUrlMissing = 62,
        #endregion

        #region Signio
        [Description("Signio Authentication Failed."), FriendlyErrorMessage("Signio Authentication Failed."), EnumMember(Value = "SignioAuthenticationFailed")]
        SignioAuthenticationFailed = 63,
        [Description("Signio Vendor Code Missing."), FriendlyErrorMessage("Signio Vendor Code Missing."), EnumMember(Value = "SignioVendorCodeMissing")]
        SignioVendorCodeMissing = 64,
        [Description("Signio service is unavailable."), FriendlyErrorMessage("Signio service is unavailable. Please try again later"), EnumMember(Value = "SignioServiceIsDown")]
        SignioServiceIsDown = 65,
        #endregion

        #region AuctionApi
        [Description("Integrate with Auction Api Param Missing."), FriendlyErrorMessage("Integrate with Auction Api Param Missing."), EnumMember(Value = "AuctionApiParamMissing")]
        AuctionApiParamMissing = 66,
        [Description("Integrate with Auction Api Param is set to no."), FriendlyErrorMessage("Integrate with Auction Api Param is set to no."), EnumMember(Value = "AuctionApiNotAllowed")]
        AuctionApiNotAllowed = 67,
        [Description("Auction Api Param credentials is missing."), FriendlyErrorMessage("Auction Api credentials is missing."), EnumMember(Value = "AuctionApiCredentialsMissing")]
        AuctionApiCredentialsMissing = 68,
        [Description("Auction Api Key is missing."), FriendlyErrorMessage("Auction Api Key is missing."), EnumMember(Value = "AuctionApiKeyMissing")]
        AuctionApiKeyMissing = 69,
        [Description("Auction Api Login Url is missing."), FriendlyErrorMessage("Auction Api Login Url is missing."), EnumMember(Value = "AuctionApiLoginUrlMissing")]
        AuctionApiLoginUrlMissing = 70,
        [Description("Auction Api Get Valuation Details Url is missing."), FriendlyErrorMessage("Auction Api Get Valuation Details Url is missing."), EnumMember(Value = "AuctionApiGetValuationUrlMissing")]
        AuctionApiGetValuationUrlMissing = 71,
        [Description("Auction Api did not return any results for the Id you supplied."), FriendlyErrorMessage("Auction Api did not return any results for the Id {0} you supplied."), EnumMember(Value = "AuctionApiDidNotReturnAnyResultsForYourId")]
        AuctionApiDidNotReturnAnyResultsForYourId = 72,
        [Description("Cannot access Auction Api."), FriendlyErrorMessage("Connection to Auction Api Service failed."), EnumMember(Value = "AuctionApiNoAccess")]
        AuctionApiNoAccess = 73,
        #endregion

        #region MmVehicles
        [Description("MM Code already exists."), FriendlyErrorMessage("There is already a vehicle with that code in the database."), EnumMember(Value = "MmCodeAlreadyExists")]
        MmCodeAlreadyExists = 79,

        //next number: 78
        #endregion

        [Description("Unspecified Error Occurred."), FriendlyErrorMessage("Unspecified Error Occurred."), EnumMember(Value = "UnspecifiedErrorOccurred")]
        UnspecifiedErrorOccurred = 78
    }
}
