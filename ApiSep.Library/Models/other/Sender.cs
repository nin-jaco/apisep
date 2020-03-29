using System;
using System.Runtime.Serialization;
using System.Web;
using ApiSep.Library.Interfaces;
using ApiSep.Library.Models.dto;

namespace ApiSep.Library.Models.other
{
    public class Sender : ISender
    {
        [DataMember] public int LocalIdUser { get; set; } = 0;
        [DataMember] public string LocalUsername { get; set; }
        [DataMember] public string LocalPassword { get; set; }
        [DataMember] public string UserEmailAddress { get; set; }
        [DataMember] public string UserMailPassword { get; set; }
        [DataMember] public DateTime RequestDateTime { get; set; } = DateTime.Now;

        public Sender()
        {
            var loggedInUser = HttpContext.Current.Session["UserDto"] as UserDto ?? new UserDto();
            //LocalIdUser = loggedInUser.IdUser;
            LocalUsername = loggedInUser.Username;
            //UserEmailAddress = loggedInUser.Email;
            //UserMailPassword = loggedInUser.ExchangePassword;

        }



    }
}
