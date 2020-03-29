using System.Collections.Generic;
using System.Runtime.Serialization;
using ApiSep.Library.BaseClasses;

namespace ApiSep.Exchange.ApiClasses.ResponseObjects
{
    [DataContract]
    public class GetEwsAppointmentsForADayResponse : ResponseBase
    {
        [DataMember]
        public List<string> AppointmentList { get; set; }
    }
}
