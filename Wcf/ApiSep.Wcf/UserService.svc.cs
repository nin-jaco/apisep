using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using ApiSep.Dal;
using ApiSep.DAL.Interfaces;

namespace ApiSep.Wcf
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class UserService : IUserService
    {
        private IApiSepContext _context = new ApiSepContext();

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }


    }
}
