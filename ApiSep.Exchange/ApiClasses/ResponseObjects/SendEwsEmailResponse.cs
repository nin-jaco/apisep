using System.Collections.Generic;
using System.Runtime.Serialization;
using ApiSep.Library.BaseClasses;

namespace ApiSep.Exchange.ApiClasses.ResponseObjects
{
    [DataContract(Namespace = "ApiSep.Exchange.ApiClasses.ResponseObjects", Name = "SendEwsEmailResponse")]
    [KnownType(typeof(SendEwsEmailResponse))]
    [KnownType(typeof(ResponseBase))]
    public class SendEwsEmailResponse : ResponseBase
    {
        [DataMember]
        public string Subject { get; set; }
        [DataMember]
        public string Body { get; set; }
        [DataMember]
        public List<string> ToRecipients { get; set; }
        [DataMember]
        public List<string> CcRecipients { get; set; }
        [DataMember]
        public List<string> BccRecipients { get; set; }
        [DataMember]
        public List<string> Attachments { get; set; }
        [DataMember]
        public bool ShouldSend { get; set; }
    }
}
