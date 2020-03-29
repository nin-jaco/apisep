using System;
using System.Runtime.Serialization;
using ApiSep.Library.Interfaces;
using ApiSep.Library.Models.other;

namespace ApiSep.Library.BaseClasses
{
    [Serializable]
    [DataContract(IsReference = true, Namespace = "ApiSep.Library.BaseClasses", Name = "RequestBase")]
    [KnownType(typeof(RequestBase))]
    public class RequestBase : ISenderEnvironment, IReceiver, ISender
    {
        [DataMember] public string SenderComputerIp { get; set; }
        [DataMember] public string SentFromUrl { get; set; }
        [DataMember] public string UserAgent { get; set; }
        [DataMember] public string Browser { get; set; }
        [DataMember] public string BrowserVersion { get; set; }

        //-->[sender]
        [DataMember] public int LocalIdUser { get; set; }
        [DataMember] public string LocalUsername { get; set; }
        [DataMember] public string LocalPassword { get; set; }
        [DataMember] public string UserEmailAddress { get; set; }
        [DataMember] public string UserMailPassword { get; set; }
        [DataMember] public int? IdWorkingAs { get; set; }
        [DataMember] public string WorkingAsUsername { get; set; }
        [DataMember] public int LocalIdDealer { get; set; }
        [DataMember] public int LocalDealerCode { get; set; }
        [DataMember] public string LocalDealerName { get; set; }
        [DataMember] public DateTime RequestDateTime { get; set; }

        //-->[Destination]
        [DataMember]
        public string Protocol { get; set; }
        [DataMember]
        public string Host { get; set; }
        [DataMember]
        public string Port { get; set; }
        [DataMember]
        public string Ip { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string HttpVerb { get; set; }

        public RequestBase GetBase()
        {
            return (RequestBase)this;
        }

        public RequestBase()
        {
            var senderEnvironment = new SenderEnvironment();
            var sender = new Sender();

            SenderComputerIp = senderEnvironment.SenderComputerIp;
            SentFromUrl = senderEnvironment.SentFromUrl;
            UserAgent = senderEnvironment.UserAgent;
            Browser = senderEnvironment.Browser;
            BrowserVersion = senderEnvironment.BrowserVersion;

            LocalIdUser = sender.LocalIdUser;
            LocalUsername = sender.LocalUsername;
            LocalPassword = sender.LocalPassword;
            UserEmailAddress = sender.UserEmailAddress;
            UserMailPassword = sender.UserMailPassword;
            IdWorkingAs = sender.IdWorkingAs;
            WorkingAsUsername = sender.WorkingAsUsername;
            LocalIdDealer = sender.LocalIdDealer;
            LocalDealerCode = sender.LocalDealerCode;
            LocalDealerName = sender.LocalDealerName;
            RequestDateTime = sender.RequestDateTime;
        }

    }
}
