using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ApiSep.Library.Models.dto
{
    [DataContract]
    public class ElmahErrorDto
    {
        [DataMember]
        [JsonProperty("errorId")]
        public System.Guid ErrorId { get; set; }

        [DataMember]
        [JsonProperty("application")]
        public string Application { get; set; }

        [DataMember]
        [JsonProperty("host")]
        public string Host { get; set; }

        [DataMember]
        [JsonProperty("type")]
        public string Type { get; set; }

        [DataMember]
        [JsonProperty("source")]
        public string Source { get; set; }

        [DataMember]
        [JsonProperty("message")]
        public string Message { get; set; }

        [DataMember]
        [JsonProperty("user")]
        public string User { get; set; }

        [DataMember]
        [JsonProperty("statusCode")]
        public int StatusCode { get; set; }

        [DataMember]
        [JsonProperty("timeUtc")]
        public System.DateTime TimeUtc { get; set; }

        [DataMember]
        [JsonProperty("sequence")]
        public int Sequence { get; set; }

        [DataMember]
        [JsonProperty("allXml")]
        public string AllXml { get; set; }

        public static ElmahErrorDto FromModel(ELMAH_Error model)
        {
            return new ElmahErrorDto()
            {
                ErrorId = model.ErrorId, 
                Application = model.Application, 
                Host = model.Host, 
                Type = model.Type, 
                Source = model.Source, 
                Message = model.Message, 
                User = model.User, 
                StatusCode = model.StatusCode, 
                TimeUtc = model.TimeUtc, 
                Sequence = model.Sequence, 
                AllXml = model.AllXml, 
            }; 
        }

        public ELMAH_Error ToModel()
        {
            return new ELMAH_Error()
            {
                ErrorId = ErrorId, 
                Application = Application, 
                Host = Host, 
                Type = Type, 
                Source = Source, 
                Message = Message, 
                User = User, 
                StatusCode = StatusCode, 
                TimeUtc = TimeUtc, 
                Sequence = Sequence, 
                AllXml = AllXml, 
            }; 
        }
    }
}