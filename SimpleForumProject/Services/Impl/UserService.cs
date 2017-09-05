using Data;
using Services.Helpers;
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

        public override void Create(User user)
        {
            user.Password = HashingHelper.HashPassword(user.Password);
            base.Create(user);
        }

        public bool CheckIfUserExists (User user)
        {
            string hashPassword = HashingHelper.HashPassword(user.Password);
            return Context.Users.Any(x => x.UserName == user.UserName && x.Password == hashPassword);
        }
    }
}
