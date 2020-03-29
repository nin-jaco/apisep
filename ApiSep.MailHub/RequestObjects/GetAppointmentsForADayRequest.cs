using System;
using System.Runtime.Serialization;
using ApiSep.Library.BaseClasses;

namespace ApiSep.MailHub.RequestObjects
{
    [DataContract]
    public class GetAppointmentsForADayRequest : RequestBase
    {
        public GetAppointmentsForADayRequest()
        {
            RequestBase = base.GetBase();
        }

        [DataMember]
        public RequestBase RequestBase { get; set; }

        [DataMember]
        public DateTime Day { get; set; }

    }
}
