using System.IO;
using System.Text;

namespace ApiSep.Library.Utilities
{
    public class StringEncoder : StringWriter
    {
        public StringEncoder(Encoding encoding)
        {
            this.Encoding = encoding;
        }

        public override Encoding Encoding { get; }
    }
}
