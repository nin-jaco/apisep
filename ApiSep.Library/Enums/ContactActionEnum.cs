using System.ComponentModel;
using System.Runtime.Serialization;
using ApiSep.Library.Attributes;

namespace ApiSep.Library.Enums
{
    [Help(@"string contactAction = ContactActionsEnum.Description();"), DataContract(Namespace = "ApiSep.Library.Enums", Name = "ContactActionsEnum")]
    public enum ContactActionEnum
    {
        [Description("Contact Created"), EnumMember(Value = "ContactCreated")]
        ContactCreated = 0,
    }
}
