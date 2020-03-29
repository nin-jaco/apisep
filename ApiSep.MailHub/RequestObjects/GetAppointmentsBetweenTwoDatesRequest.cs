using System;
using System.Runtime.Serialization;
using ApiSep.Library.BaseClasses;

namespace ApiSep.MailHub.RequestObjects
{
    [DataContract]
    public class GetAppointmentsBetweenTwoDatesRequest : RequestBase
    {
        public GetAppointmentsBetweenTwoDatesRequest()
        {
            RequestBase = base.GetBase();
        }

        [DataMember]
        public RequestBase RequestBase { get; set; }
        [DataMember]
        public DateTime StartDate { get; set; }
        [DataMember]
        public DateTime EndDate { get; set; }
    }
}
