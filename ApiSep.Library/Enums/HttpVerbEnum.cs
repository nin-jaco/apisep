using System.ComponentModel;
using System.Runtime.Serialization;
using ApiSep.Library.Attributes;

namespace ApiSep.Library.Enums
{
    [Help(@"string verbDescription = HttpVerbEnum.Description();"), DataContract(Namespace = "ApiSep.Library.Enums", Name = "HttpVerbEnum")]
    public enum HttpVerbEnum
    {
        [Description("GET"), EnumMember(Value = "GET")]
        GET = 0,
        [Description("POST"), EnumMember(Value = "POST")]
        POST = 1,
        [Description("PUT"), EnumMember(Value = "PUT")]
        PUT = 2,
        [Description("DELETE"), EnumMember(Value = "DELETE")]
        DELETE = 3

    }
}
