using System.Runtime.Serialization;

namespace ApiSep.Library.Enums
{
    [DataContract(Namespace = "ApiSep.Library.Enums", Name = "ControlTypeEnum")]
    public enum ControlTypeEnum
    {
        [EnumMember(Value = "TextBox")]
        TextBox = 1,
        [EnumMember(Value = "DropDownList")]
        DropDownList = 2,
    }
}
