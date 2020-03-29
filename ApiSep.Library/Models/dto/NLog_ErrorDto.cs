using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ApiSep.Library.Models.dto
{
    [DataContract]
    public class NLogErrorDto
    {
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        [DataMember]
        [JsonProperty("time_stamp")]
        public System.DateTime time_stamp { get; set; }

        [DataMember]
        [JsonProperty("host")]
        public string host { get; set; }

        [DataMember]
        [JsonProperty("type")]
        public string type { get; set; }

        [DataMember]
        [JsonProperty("source")]
        public string source { get; set; }

        [DataMember]
        [JsonProperty("message")]
        public string message { get; set; }

        [DataMember]
        [JsonProperty("level")]
        public string level { get; set; }

        [DataMember]
        [JsonProperty("logger")]
        public string logger { get; set; }

        [DataMember]
        [JsonProperty("stacktrace")]
        public string stacktrace { get; set; }

        [DataMember]
        [JsonProperty("allxml")]
        public string allxml { get; set; }

        public static NLogErrorDto FromModel(NLog_Error model)
        {
            return new NLogErrorDto()
            {
                Id = model.Id, 
                time_stamp = model.time_stamp, 
                host = model.host, 
                type = model.type, 
                source = model.source, 
                message = model.message, 
                level = model.level, 
                logger = model.logger, 
                stacktrace = model.stacktrace, 
                allxml = model.allxml, 
            }; 
        }

        public NLog_Error ToModel()
        {
            return new NLog_Error()
            {
                Id = Id, 
                time_stamp = time_stamp, 
                host = host, 
                type = type, 
                source = source, 
                message = message, 
                level = level, 
                logger = logger, 
                stacktrace = stacktrace, 
                allxml = allxml, 
            }; 
        }
    }
}