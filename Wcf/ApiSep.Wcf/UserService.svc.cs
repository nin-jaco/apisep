using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using ApiSep.Dal.Entities;
using ApiSep.ErrorLogger.Services.Wcf;

namespace ApiSep.Wcf
{
    [GlobalErrorBehavior(typeof(GlobalErrorHandler))]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class UserService : IUserService
    {
        private ApiSepEntities Context { get; } = new ApiSepEntities();

        public List<User> GetAll()
        {
            return Context.Users.ToList();
        }


    }
}
