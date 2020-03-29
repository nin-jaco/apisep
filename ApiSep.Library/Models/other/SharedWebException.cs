using System.Runtime.Serialization;

namespace ApiSep.Library.Models.other
{
    [DataContract]
    public class SharedWebException
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public System.DateTime LoggedDate { get; set; }
        [DataMember]
        public string CallerFilePath { get; set; }
        [DataMember]
        public string CallerMemberName { get; set; }
        [DataMember]
        public string RequestUrl { get; set; }
        [DataMember]
        public string Host { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string DealerName { get; set; }
        [DataMember]
        public string ExceptionMessage { get; set; }
        [DataMember]
        public string ExceptionType { get; set; }
        [DataMember]
        public string StackTrace { get; set; }
        [DataMember]
        public string InnerExceptionType { get; set; }
        [DataMember]
        public string InnerExceptionMessage { get; set; }
        [DataMember]
        public string InnerExceptionSource { get; set; }
        [DataMember]
        public string InnerExceptionStackTrace { get; set; }
    }
}
