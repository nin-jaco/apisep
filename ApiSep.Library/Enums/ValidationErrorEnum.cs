using System.ComponentModel;
using System.Runtime.Serialization;

namespace ApiSep.Library.Enums
{
    [DataContract(Namespace = "ApiSep.Library.Enums", Name = "ValidationErrorEnum")]
    public enum ValidationErrorEnum
    {
        [Description("Format is not valid"), EnumMember(Value = "InvalidFormat")]
        InvalidFormat = 0,
        [Description("Field is mandatory"), EnumMember(Value = "MandatoryField")]
        MandatoryField =1
    }
}
