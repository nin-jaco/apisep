using System;

namespace ApiSep.Library.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]

    public class DecimalFormatterAttribute : Attribute
    {
        public DecimalFormatterAttribute(string formatString)
        {
            Format = formatString;
        }

        public string Format { get; private set; }
    }
}
