using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class IdProvider
    {
        private DateTime dateTime;

        public int Id { get; set; }

        public DateTime DateTime
        {
            get
            {
                if (dateTime == DateTime.MinValue)
                {
                    dateTime = DateTime.Now;
                }
                return dateTime;
            }

            set
            {
                dateTime = value;
            }
        }
    }
}
