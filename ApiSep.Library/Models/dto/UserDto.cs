using System.Runtime.Serialization;
using ApiSep.Dal.Entities;
using ApiSep.DAL;
using Newtonsoft.Json;

namespace ApiSep.Library.Models.dto
{
    [DataContract]
    public class UserDto
    {
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        [DataMember]
        [JsonProperty("username")]
        public string Username { get; set; }

        [DataMember]
        [JsonProperty("firstname")]
        public string Firstname { get; set; }

        [DataMember]
        [JsonProperty("lastname")]
        public string Lastname { get; set; }

        [DataMember]
        [JsonProperty("dateOfBirth")]
        public System.DateTime DateOfBirth { get; set; }

        [DataMember]
        [JsonProperty("dateCreated")]
        public System.DateTime DateCreated { get; set; }

        public static UserDto FromModel(User model)
        {
            return new UserDto()
            {
                Id = model.Id, 
                Username = model.Username, 
                Firstname = model.Firstname, 
                Lastname = model.Lastname, 
                DateOfBirth = model.DateOfBirth, 
                DateCreated = model.DateCreated, 
            }; 
        }

        public User ToModel()
        {
            return new User()
            {
                Id = Id, 
                Username = Username, 
                Firstname = Firstname, 
                Lastname = Lastname, 
                DateOfBirth = DateOfBirth, 
                DateCreated = DateCreated, 
            }; 
        }
    }
}