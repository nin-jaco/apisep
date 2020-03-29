using System.Collections.Generic;
using System.Runtime.Serialization;
using ApiSep.Library.BaseClasses;

namespace ApiSep.MailHub.RequestObjects
{
    [DataContract(Namespace = "ApiSep.MailHub.RequestObjects", Name = "EmailRequest")]
    [KnownType(typeof(EmailRequest))]
    [KnownType(typeof(RequestBase))]
    public class EmailRequest : RequestBase
    {
        public EmailRequest()
        {
            RequestBase = this.GetBase();
        }

        [DataMember]
        public RequestBase RequestBase { get; set; }
        
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
        public List<string> Attachments  { get; set; }
        //[DataMember]
        //public string DocumentName { get; set; }
        [DataMember]
        public bool ShouldSend { get; set; }
        [DataMember]
        public bool SendReadReceipt { get; set; }

        [DataMember]
        public string EmailClientTypeEnum { get; set; }
        [DataMember]
        public string Domain { get; set; }
        [DataMember]
        public string ExchangeServiceUrl { get; set; }
    }
}


