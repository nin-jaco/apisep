using System.Collections.Generic;
using System.Runtime.Serialization;
using ApiSep.Library.BaseClasses;

namespace ApiSep.MailHub.ResponseObjects
{
    [DataContract(Namespace = "ApiSep.MailHub.ResponseObjects", Name = "EmailResponse")]
    [KnownType(typeof(EmailResponse))]
    [KnownType(typeof(ResponseBase))]
    public class EmailResponse : ResponseBase
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
