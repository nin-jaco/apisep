using System.Runtime.Serialization;
using ApiSep.Library.BaseClasses;
using Serialize.Linq.Nodes;

namespace ApiSep.Library.RequestObjects
{
    [DataContract]
    public class SearchForRequest<TDto> : RequestBase
    {
        [DataMember]
        public ExpressionNode Predicate { get; set; }
        [DataMember] public RequestBase RequestBase { get; set; }

        public SearchForRequest()
        {
            RequestBase = base.GetBase();
        }

        public SearchForRequest(ExpressionNode predicate, RequestBase requestBase)
        {
            Predicate = predicate;
            RequestBase = requestBase;
        }
    }
}
