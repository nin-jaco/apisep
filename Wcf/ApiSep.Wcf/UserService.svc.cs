using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Web.ModelBinding;
using ApiSep.Bl.BaseClasses;
using ApiSep.Dal.Entities;
using ApiSep.Library.Models.dto;
using ApiSep.Library.RequestObjects;
using ApiSep.Library.ResponseObjects;
using ApiSep.Wcf.BaseClasses;

namespace ApiSep.Wcf
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class UserService : IUserService
    {
        ApiSepEntities ApisetApiSepContext = new ApiSepEntities();

        public List<User> GetAll()
        {
            return ApisetApiSepContext.Users.ToList();
        }

        
    }
}
