using System;
using System.Runtime.Serialization;
using System.Web;
using ApiSep.Library.Interfaces;

namespace ApiSep.Library.Models.other
{
    [Serializable]
    [DataContract]
    public class SenderEnvironment : ISenderEnvironment
    {
        [DataMember]
        public string SenderComputerIp { get; set; } = GetUserIp();
        [DataMember]
        public string SentFromUrl { get; set; } = HttpContext.Current.Request.Url?.AbsoluteUri;
        [DataMember]
        public string UserAgent { get; set; } = HttpContext.Current.Request.UserAgent;
        [DataMember]
        public string Browser { get; set; } = HttpContext.Current.Request.Browser.Browser;
        [DataMember]
        public string BrowserVersion { get; set; } = HttpContext.Current.Request.Browser.Version;

        private static string GetUserIp()
        {
            string ipList = HttpContext.Current.Request.ServerVariables["HTTP_X_CLUSTER_CLIENT_IP"];

            if (!string.IsNullOrEmpty(ipList))
            {
                return ipList.Split(',')[0];
            }

            ipList = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipList))
            {
                return ipList.Split(',')[0];
            }

            return HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }
    }
}
