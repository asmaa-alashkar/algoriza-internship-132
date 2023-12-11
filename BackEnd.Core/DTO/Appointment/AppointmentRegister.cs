using BackEnd.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Core.DTO.Appointment
{
    public class AppointmentRegister
    {
        public double Price { get; set; }
        public List<Days> Days { get; set; }
        //public virtual List<Time> Times { get; set; }
    }
}
