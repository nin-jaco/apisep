using System;
using System.Runtime.Serialization;

namespace ApiSep.Exchange.ApiClasses.RequestObjects
{
    [DataContract]
    public class GetEwsAppointmentsForADayRequest : EwsRequestBase
    {
        [DataMember]
        public DateTime Day { get; set; }
    }
}
