using BackEnd.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Core.Models
{
    public class Doctor : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Image { get; set; }
        public int SpecializationId { get; set; }
        public virtual Specialization Specialization { get; set; }
        public virtual List<Patient> Patients { get; set; }
        public virtual List<Appointment> Appointments { get; set; }
        public virtual List<Booking> Bookings { get; set; }
        public virtual List<Request> Requests { get; set; }



    }

}
