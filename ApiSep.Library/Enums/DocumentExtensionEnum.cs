using System.ComponentModel;
using System.Runtime.Serialization;
using ApiSep.Library.Attributes;

namespace ApiSep.Library.Enums
{
    [Help(@"string documentType = DocumentType.Description();"), DataContract(Namespace = "ApiSep.Library.Enums", Name = "DocumentExtensionEnum")]
    public enum DocumentExtensionEnum
    {
        [Description("pdf"), EnumMember(Value = "Pdf")]
        Pdf = 0,
        [Description("xls"), EnumMember(Value = "Xls")]
        Xls = 1,
        [Description("txt"), EnumMember(Value = "Txt")]
        Txt = 2,
        [Description("xlsx"), EnumMember(Value = "Xlsx")]
        Xlsx = 3,
        [Description("docx"), EnumMember(Value = "Docx")]
        Docx = 4,
        [Description("doc"), EnumMember(Value = "Doc")]
        Doc = 5,
        [Description("xml"), EnumMember(Value = "Xml")]
        Xml = 6,
        [Description("png"), EnumMember(Value = "Png")]
        Png = 7,
        [Description("jpg"), EnumMember(Value = "Jpg")]
        Jpg = 8,
        [Description("gif"), EnumMember(Value = "Gif")]
        Gif = 9,
    }
}
