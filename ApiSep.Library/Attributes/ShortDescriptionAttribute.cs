using System;

namespace ApiSep.Library.Attributes
{
    public class ShortDescriptionAttribute : Attribute
    {
        public string ShortDescription;

        [Help(@"For use in the DocumentType enum")]
        public ShortDescriptionAttribute(string shortDescription)
        {
            ShortDescription = shortDescription;
        }
    }
}
