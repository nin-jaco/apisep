using System.Collections.Generic;
using System.Runtime.Serialization;
using ApiSep.Library.BaseClasses;

namespace ApiSep.Library.ResponseObjects
{
    [DataContract]
    public class GetAllPagedResponse<TDto> : ResponseBase where TDto : class, new()
    {
        [DataMember] public List<TDto> ItemList { get; set; }
    }
}
