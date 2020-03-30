﻿using System.Runtime.Serialization;
using ApiSep.Library.BaseClasses;

namespace ApiSep.Exchange.ApiClasses.ResponseObjects
{
    [DataContract]
    public class CreateEwsAppointmentResponse : ResponseBase
    {
        [DataMember]
        public string UniqueId { get; set; }
        
    }
}