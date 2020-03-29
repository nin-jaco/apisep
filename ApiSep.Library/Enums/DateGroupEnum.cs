using System.ComponentModel;
using System.Runtime.Serialization;

namespace ApiSep.Library.Enums
{
    [DataContract(Namespace = "ApiSep.Library.Enums", Name = "DateGroupEnum")]
    public enum DateGroupEnum
    {
        [Description("Custom Dates"), EnumMember(Value = "CustomDates")]
        CustomDates = 0,
        [Description("Last Month"), EnumMember(Value = "LastMonth")]
        LastMonth = 1,
        [Description("Last Three Months"), EnumMember(Value = "LastThreeMonths")]
        LastThreeMonths = 2,
        [Description("Last Six Months"), EnumMember(Value = "LastSixMonths")]
        LastSixMonths = 3,
        [Description("This Week"), EnumMember(Value = "ThisWeek")]
        ThisWeek = 4,
        [Description("This Month"), EnumMember(Value = "ThisMonth")]
        ThisMonth = 5,
        [Description("This Year"), EnumMember(Value = "ThisYear")]
        ThisYear = 6,
        [Description("Today"), EnumMember(Value = "Today")]
        Today = 7,
        [Description("Last Seven Days"), EnumMember(Value = "LastSevenDays")]
        LastSevenDays = 8,
        [Description("Last Thirty Days"), EnumMember(Value = "LastThirtyDays")]
        LastThirtyDays = 9

    }
}
