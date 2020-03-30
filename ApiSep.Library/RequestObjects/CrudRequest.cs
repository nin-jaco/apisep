using System;
using System.Runtime.Serialization;

namespace ApiSep.Library.RequestObjects
{
    [DataContract(Namespace = "ApiSep.Library.RequestObjects", Name = "CrudRequest")]
    [KnownType(typeof(CrudRequest))]
    public class CrudRequest
    {
        [DataMember]
        public int IdChangedBy { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public int IdDealer { get; set; }

        [DataMember]
        public string DealerName { get; set; }

        [DataMember]
        public string IpAddress { get; set; }

        [DataMember]
        public string UserAgent { get; set; }

        [DataMember]
        public string Browser { get; set; }

        [DataMember]
        public string BrowserVersion { get; set; }

        [DataMember]
        public string RequestUrl { get; set; }
        [DataMember]
        public Nullable<int> IdWorkingAs { get; set; }
        [DataMember]
        public string WorkingAsUsername { get; set; }

    }
}
