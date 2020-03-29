using System;
using System.IO;
using System.Net;

namespace ApiSep.Library.Extensions
{
    public static class ExceptionExtensions
    {
        public static string ReadWebExceptionResponse(this WebException wex)
        {
            if(wex.Response.GetResponseStream() == null) throw wex;

            using (var reader = new StreamReader(wex.Response.GetResponseStream() ?? throw new InvalidOperationException()))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
