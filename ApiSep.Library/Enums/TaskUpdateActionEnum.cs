using System.ComponentModel;
using System.Runtime.Serialization;
using ApiSep.Library.Attributes;

namespace ApiSep.Library.Enums
{
    [Help(@"string taskStatus = status.Description();"), DataContract(Name = "TaskUpdateActionEnum",Namespace = "ApiSep.Library.Enums")]
    public enum TaskUpdateActionEnum
    {
        [Description("Client was called"), EnumMember(Value = "CallClient")]
        CallClient = 0,
        [Description("Client was emailed"), EnumMember(Value = "EmailClient")]
        EmailClient = 1,
        [Description("A meeting was rescheduled"), EnumMember(Value = "Reschedule")]
        Reschedule = 2,
        [Description("The client was called previously"), EnumMember(Value = "Phoned")]
        Phoned = 3,
        [Description("Client was emailed previously"), EnumMember(Value = "Emailed")]
        Emailed = 4,
        [Description("Other"), EnumMember(Value = "Other")]
        Other = 5
    }
}
