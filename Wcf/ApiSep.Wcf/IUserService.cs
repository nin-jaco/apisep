using System.Collections.Generic;
using System.ServiceModel;
using ApiSep.Dal;
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
