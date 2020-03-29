using System.Runtime.Serialization;
using ApiSep.Library.BaseClasses;

namespace ApiSep.Exchange.ApiClasses.RequestObjects
{
    [DataContract]
    public class EwsRequestBase : RequestBase
    {
        [DataMember]
        public string LoginName { get; set; }
        
        [DataMember]
        public string Domain { get; set; }
        [DataMember]
        public string ExchangeServiceUrl { get; set; }
        [DataMember]
        public string DealerName { get; set; }

        public EwsRequestBase()
        {
            RequestBase = this.GetBase();
        }

        [DataMember]
        public RequestBase RequestBase { get; set; }
    }
}