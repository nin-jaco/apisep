using System.Runtime.Serialization;
using ApiSep.Library.BaseClasses;

namespace ApiSep.Library.RequestObjects
{
    [DataContract]
    public class GetAllRequest : RequestBase
    {
        [DataMember]
        public RequestBase RequestBase { get; set; }

        public GetAllRequest()
        {
            RequestBase = base.GetBase();
        }

        public GetAllRequest(RequestBase requestBase)
        {
            RequestBase = requestBase;
        }

    }
}
