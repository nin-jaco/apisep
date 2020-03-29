using System.Runtime.Serialization;
using ApiSep.Library.BaseClasses;

namespace ApiSep.Library.RequestObjects
{
    [DataContract]
    public class DeleteRequest<T> : RequestBase
    {
        [DataMember] public T Item { get; set; }
        [DataMember] public RequestBase RequestBase { get; set; }

        public DeleteRequest()
        {
            RequestBase = base.GetBase();
        }

        public DeleteRequest(T item, RequestBase requestBase)
        {
            Item = item;
            RequestBase = requestBase;
        }


    }
}
