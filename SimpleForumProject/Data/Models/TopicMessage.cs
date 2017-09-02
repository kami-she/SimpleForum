using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class TopicMessage : IdProvider
    {
        public string Text { get; set; }

        public int OwnerId { get; set; }

        public int TopicId { get; set; }

        public virtual User Owner { get; set; }

        public virtual Topic Topic { get; set; }
    }
}
