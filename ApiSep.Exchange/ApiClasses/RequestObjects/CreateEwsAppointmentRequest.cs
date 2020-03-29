using System;
using System.Runtime.Serialization;

namespace ApiSep.Exchange.ApiClasses.RequestObjects
{
    [DataContract]
    public class CreateEwsAppointmentRequest : EwsRequestBase
    {
        [DataMember]
        public string Recipients{get; set;} 
        [DataMember]
        public string Body{get; set;} 
        [DataMember]
        public string Subject{get; set;} 
        [DataMember]
        public DateTime StartTimeUtc{get; set;} 
        [DataMember]
        public DateTime EndTimeUtc{get; set;} 
        [DataMember]
        public string Location{get; set;} 
        [DataMember]
        public DateTime Reminder { get; set; }
    }
}
