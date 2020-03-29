using System;

namespace ApiSep.Library.Attributes
{
    public class XslNameAttribute : Attribute
    {
        public string XslName;
        public XslNameAttribute(string xslName)
        {
            XslName = xslName;
        }
    }
}
