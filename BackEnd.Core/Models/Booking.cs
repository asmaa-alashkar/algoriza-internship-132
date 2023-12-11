using BackEnd.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Core.Models
{
    public class Booking:EntityBase
    {
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Appointment Appointment { get; set; }
        public int AppointmentId  { get; set; }

        public int DiscoundId { get; set; }
        public virtual Discound Discound { get; set; }
    }
}
