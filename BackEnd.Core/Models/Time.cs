using BackEnd.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Core.Models
{
    public class Time:EntityBase
    {
        public string DTime { get; set; }
        public virtual List<Booking> Bookings { get; set; }
        public virtual List<Request> Requests { get; set; }

    }
}
