using BackEnd.Core.Common;

namespace BackEnd.Core.Models
{
    public class Specialization : EntityBase
    {
        public string Name { get; set; }
        public virtual List<Doctor> Doctors { get; set; }
        public virtual List<Request> Requests { get; set; }

    }

}
