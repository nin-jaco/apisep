using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ApiSep.Exchange.ApiClasses.RequestObjects
{
    [DataContract(Namespace = "ApiSep.Exchange.ApiClasses.RequestObjects", Name = "SendEmailRequest")]
    [KnownType(typeof(SendEwsEmailRequest))]
    [KnownType(typeof(EwsRequestBase))]
    public class SendEwsEmailRequest : EwsRequestBase
    {
        //this is the sender whose credentials are to be used to authenticate in exchange
        [DataMember]
        public string Subject { get; set; }
        [DataMember]
        public string Body { get; set; }
        [DataMember]
        public List<string> ToRecipients { get; set; } = new List<string>();
        [DataMember]
        public List<string> CcRecipients { get; set; } = new List<string>();
        [DataMember]
        public List<string> BccRecipients { get; set; } = new List<string>();
        //todo: what about more than one attachment?
        [DataMember]
        public bool HasAttachment { get; set; }
        [DataMember]
        public List<string> Attachments { get; set; }
        //[DataMember]
        //public string FileName { get; set; }
        [DataMember]
        public bool ShouldSend { get; set; }
        [DataMember]
        public bool SendReadReceipt { get; set; }
    }
}
