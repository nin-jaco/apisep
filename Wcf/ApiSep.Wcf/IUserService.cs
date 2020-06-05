using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ApiSep.Dal.Entities;
using ApiSep.Library.Models.dto;

namespace ApiSep.Wcf
{
    [ServiceContract(Namespace = "ApiSep.Wcf", Name = "UserService", SessionMode = SessionMode.NotAllowed)]
    [ServiceKnownType(typeof(UserDto))]
    public interface IUserService
    {
        [OperationContract]
        List<User> GetAll();
    }
}
