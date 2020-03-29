using System.Collections.Generic;
using System.Runtime.Serialization;
using ApiSep.Library.BaseClasses;
using Microsoft.Exchange.WebServices.Data;

namespace ApiSep.Exchange.ApiClasses.ResponseObjects
{
    [DataContract]
    public class GetEwsAppointmentsBetweenTwoDatesResponse : ResponseBase
    {
        [DataMember]
        public List<Appointment> AppointmentList { get; set; }
    }
}
