using BackEnd.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Core.Models
{
    public class Appointment:EntityBase
    {
        public double Price { get; set; }
        public Days Days { get; set; }
        public virtual List<Time> Times { get; set; }
        public virtual List<Booking> Bookings { get; set; }

    }
    public enum Days
    {
        Monday, 
        Tuesday, 
        Wednesday, 
        Thursday, 
        Friday, 
        Saturday, 
        Sunday
    }
}
