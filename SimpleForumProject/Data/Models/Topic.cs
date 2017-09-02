using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Topic : IdProvider
    {
        public string Header { get; set; }

        public string Text { get; set; }

        public int OwnerId { get; set; }

        public virtual User Owner { get; set; }

        public virtual ICollection<TopicMessage> TopicMessages { get; set; }
    }
}
