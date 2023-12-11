using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Core.DTO.Specialization
{
    public class SpecializationGet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? CreatedBy { get; set; }
    }
}
