using BackEnd.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Core.Models
{
    public class Request:EntityBase
    {  
        public RequestStatus RequestStatus { get; set; }
        public string Image { get; set; }
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public int SpecializationId { get; set; }
        public virtual Specialization Specialization { get; set; }
        public Days Days { get; set; }
        public int TimeId { get; set; }
        public virtual Time Time { get; set; }
        public double Price { get; set; }
        public double FinalPrice { get; set; }
        public int DiscoundId { get; set; }
        public virtual Discound Discound { get; set; }
    }
    public enum RequestStatus
    {
        Pending,
        completed,
        Cancelled
    }
}
