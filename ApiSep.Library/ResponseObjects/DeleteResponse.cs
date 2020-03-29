﻿using System.Runtime.Serialization;
using ApiSep.Library.BaseClasses;

namespace ApiSep.Library.ResponseObjects
{
    [DataContract]
    public class DeleteResponse<TDto> : ResponseBase where TDto : class, new()
    {
        [DataMember] public TDto Item { get; set; }
    }
}
