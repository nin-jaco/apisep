using System;
using System.Runtime.Serialization;

namespace ApiSep.Exchange.ApiClasses.RequestObjects
{
    [DataContract]
    public class GetEwsAppointmentsBetweenTwoDatesRequest : EwsRequestBase
    {
        [DataMember]
        public DateTime StartDate { get; set; }
        [DataMember]
        public DateTime EndDate { get; set; }
    }
}
