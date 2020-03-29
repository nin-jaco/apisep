using System.Runtime.Serialization;
using ApiSep.Library.BaseClasses;

namespace ApiSep.MailHub.RequestObjects
{
    [DataContract]
    public class CreateAppointmentRequest : RequestBase
    {
        public CreateAppointmentRequest()
        {
            RequestBase = base.GetBase();
        }

        [DataMember]
        public RequestBase RequestBase { get; set; }
    }
}
