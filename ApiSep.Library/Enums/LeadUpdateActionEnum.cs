using System.ComponentModel;
using System.Runtime.Serialization;
using ApiSep.Library.Attributes;

namespace ApiSep.Library.Enums
{
    [Help(@"string taskStatus = status.Description();"), DataContract(Name = "LeadUpdateActionEnum", Namespace = "ApiSep.Library.Enums")]
    public enum LeadUpdateActionEnum
    {
        [Description("Flag lead as contacted"), EnumMember(Value = "ContactLead")]
        ContactLead = 0,
        [Description("Flag lead as converted to a contact"), EnumMember(Value = "ConvertToContact")]
        ConvertToContact = 1,
        [Description("Flag lead as being cancelled"), EnumMember(Value = "CancelLead")]
        CancelLead = 2,
        [Description("Lead Activity determined by current state"), EnumMember(Value = "Determine")]
        Determine = 3,
        [Description("Flag lead as allocated"), EnumMember(Value = "Allocate")]
        Allocate = 4,
        [Description("Flag lead a in deal"), EnumMember(Value = "Deal")]
        Deal = 5,
        [Description("Flag lead as having taken delivery"), EnumMember(Value = "Delivery")]
        Delivery = 6,
        [Description("Lead flag as sent to Retail Reg."), EnumMember(Value = "RetailReg ")]
        RetailReg = 7,
        [Description("Unmark lead as cancelled"), EnumMember(Value = "UnCancelLead")]
        UnCancelLead = 8,
        [Description("Unmark lead as pending"), EnumMember(Value = "Pending")]
        Pending = 9
    }
}
