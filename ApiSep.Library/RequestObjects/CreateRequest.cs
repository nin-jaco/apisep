using System.Runtime.Serialization;
using ApiSep.Library.BaseClasses;

namespace ApiSep.Library.RequestObjects
{
    [DataContract]
    public class CreateRequest<T> : RequestBase where T : new()
    {
        [DataMember]
        public T Item { get; set; }

        [DataMember]
        public RequestBase RequestBase { get; set; }

        public CreateRequest(T item)
        {
            Item = item;
            RequestBase = base.GetBase();
        }

        public CreateRequest(T item, RequestBase requestBase)
        {
            Item = item;
            RequestBase = requestBase;
        }




    }
}
