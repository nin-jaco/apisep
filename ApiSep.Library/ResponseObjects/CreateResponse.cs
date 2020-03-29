using System.Runtime.Serialization;
using ApiSep.Library.BaseClasses;

namespace ApiSep.Library.ResponseObjects
{
    [DataContract]
    public class CreateResponse<TDto> : ResponseBase where TDto : class, new()
    {
        [DataMember] public TDto Item { get; set; }

    }
}
