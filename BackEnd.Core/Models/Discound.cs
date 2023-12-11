using BackEnd.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Core.Models
{
    public class Discound:EntityBase
    {
        public string DiscoundCode { get; set; }
        public DiscoundType Type { get; set; }
        public string Value { get; set; }
        public virtual List<Booking> Bookings { get; set; }
        public virtual List<Request> Requests { get; set; }


    }
    public enum DiscoundType
    {
        Full,
        Half
    }
}
