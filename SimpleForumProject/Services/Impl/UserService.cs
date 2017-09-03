using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impl
{
    public class UserService : IUserService
    {
        private IForumContext context;

        public UserService (IForumContext context)
        {
            this.context = context;
        }

        public void AddUser (User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public bool GetUser (User user)
        {
            return context.Users.Any(x => x.UserName == user.UserName && x.Password == user.Password);
        }
    }
}
