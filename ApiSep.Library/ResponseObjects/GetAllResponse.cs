using System.Collections.Generic;
using System.Runtime.Serialization;
using ApiSep.Library.BaseClasses;

namespace ApiSep.Library.ResponseObjects
{
    [DataContract]
    public class GetAllResponse<TDto> : ResponseBase
    {
        [DataMember] public List<TDto> ItemList { get; set; }
    }
}
