using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class User : IdProvider
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public virtual ICollection<Topic> Topics { get; set; }

        public virtual ICollection<TopicMessage> TopicMessages { get; set; }
    }
}
