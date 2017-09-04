using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impl
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService (IForumContext context) : base(context)
        {
        }

        public bool CheckIfUserExists (User user)
        {
            return Context.Users.Any(x => x.UserName == user.UserName && x.Password == user.Password);
        }
    }
}
