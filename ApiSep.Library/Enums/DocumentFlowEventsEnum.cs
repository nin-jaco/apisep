using System.ComponentModel;
using System.Runtime.Serialization;

namespace ApiSep.Library.Enums
{
    [DataContract(Namespace = "ApiSep.Library.Enums", Name = "DocumentFlowEventsEnum")]
    public enum DocumentFlowEventsEnum
    {
        [Description("Document Added"), EnumMember(Value = "DocumentAdded")]
        DocumentAdded = 0,
        [Description("Document Cancelled"), EnumMember(Value = "DocumentCancelled")]
        DocumentCancelled = 1,
        [Description("Document Completed"), EnumMember(Value = "DocumentCompleted")]
        DocumentCompleted = 2,
        [Description("Document Delete"), EnumMember(Value = "DocumentDelete")]
        DocumentDelete = 3,
        [Description("Document Pending Release"), EnumMember(Value = "DocumentPendingRelease")]
        DocumentPendingRelease = 4,
        [Description("Document Released"), EnumMember(Value = "DocumentReleased")]
        DocumentReleased = 5,
        [Description("Document Restart"), EnumMember(Value = "DocumentRestart")]
        DocumentRestart = 6,
        [Description("Document Signed"), EnumMember(Value = "DocumentSigned")]
        DocumentSigned = 7,
        [Description("Form Submitted"), EnumMember(Value = "FormSubmitted")]
        FormSubmitted = 8
    }
}
