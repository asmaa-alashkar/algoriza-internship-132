using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Core.DTO.Time
{
    public class TimeEdit
    {
        public DateTime Created { get; set; }
        public DateTime Modified { get; set;}
        public string? ModifiedBy { get; set; }


    }
}
