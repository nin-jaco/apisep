using System.ComponentModel;
using System.Runtime.Serialization;

namespace ApiSep.Library.Enums
{
    [DataContract(Namespace = "ApiSep.Library.Enums", Name = "NotificationTypeEnum")]
    public enum NotificationTypeEnum
    {
        [Description("New Lead Created"), EnumMember(Value = "NewLeadCreated")]
        NewLeadCreated = 0,
        [Description("Electronic Document Status Changed"), EnumMember(Value = "ElectronicDocumentStatusChanged")]
        ElectronicDocumentStatusChanged = 1,
    }
}
