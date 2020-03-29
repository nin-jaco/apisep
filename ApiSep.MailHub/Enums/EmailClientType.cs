using System.ComponentModel;
using System.Runtime.Serialization;
using ApiSep.Library.Attributes;

namespace ApiSep.MailHub.Enums
{
    [Help(@"string verbDescription = HttpVerbEnum.Description();"), DataContract(Namespace = "ApiSep.MailHub.Enums", Name = "EmailClientTypeEnum")]
    public enum EmailClientTypeEnum
    {
        [Description("HostedExchange"), EnumMember(Value = "HostedExchange")]
        HostedExchange = 1,
        [Description("Smtp"), EnumMember(Value = "Smtp")]
        Smtp = 2,
        [Description("Zimbra"), EnumMember(Value = "Zimbra")]
        Zimbra = 3,
        [Description("NotSpecified"), EnumMember(Value = "NotSpecified")]
        NotSpecified = 4
    }
}
