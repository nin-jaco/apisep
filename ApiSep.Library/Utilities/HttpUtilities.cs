using System;
using System.IO;
using System.Net;
using System.Text;
using ApiSep.Library.Enums;

namespace ApiSep.Library.Utilities
{
    public class HttpUtilities
    {
        public class RestClient
        {
            public string EndPoint { get; set; }
            public HttpVerbEnum Method { get; set; }
            public string ContentType { get; set; }
            public string PostData { get; set; }

            //"application/json; charset=utf-8"

            public RestClient()
            {
                EndPoint = "";
                Method = HttpVerbEnum.GET;
                ContentType = "text/xml";
                PostData = "";
            }

            public RestClient(string endpoint)
            {
                EndPoint = endpoint;
                Method = HttpVerbEnum.GET;
                ContentType = "text/xml";
                PostData = "";
            }

            public RestClient(string endpoint, HttpVerbEnum method)
            {
                EndPoint = endpoint;
                Method = method;
                ContentType = "text/xml";
                PostData = "";
            }

            public RestClient(string endpoint, HttpVerbEnum method, string postData)
            {
                EndPoint = endpoint;
                Method = method;
                ContentType = "text/xml";
                PostData = postData;
            }


            public string MakeRequest()
            {
                return MakeRequest("");
            }

            public string MakeRequest(string parameters)
            {
                var request = (HttpWebRequest) WebRequest.Create(EndPoint + parameters);

                request.Method = Method.ToString();
                request.ContentLength = 0;
                request.ContentType = ContentType;

                if (!string.IsNullOrEmpty(PostData) && Method == HttpVerbEnum.POST)
                {
                    var encoding = new UTF8Encoding();
                    var bytes = Encoding.GetEncoding("iso-8859-1").GetBytes(PostData);
                    request.ContentLength = bytes.Length;

                    using (var writeStream = request.GetRequestStream())
                    {
                        writeStream.Write(bytes, 0, bytes.Length);
                    }
                }

                using (var response = (HttpWebResponse) request.GetResponse())
                {
                    var responseValue = string.Empty;

                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        var message = $"Request failed. Received HTTP {response.StatusCode}";
                        throw new ApplicationException(message);
                    }

                    // grab the response
                    using (var responseStream = response.GetResponseStream())
                    {
                        if (responseStream != null)
                            using (var reader = new StreamReader(responseStream))
                            {
                                responseValue = reader.ReadToEnd();
                            }
                    }

                    return responseValue;
                }
            }

        }
    }
}
