using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    class ForumContext : DbContext, IForumContext
    {
        public ForumContext() : base("ForumContext")
        {

        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Topic> Topics { get; set; }

        public virtual DbSet<TopicMessage> TopicMessages { get; set; }
    }
}
