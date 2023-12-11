using BackEnd.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Core.DTO.Discount
{
    public class DiscoundEdit
    {
        public int Id { get; set; }
        public string DiscoundCode { get; set; }
        public DiscoundType Type { get; set; }
        public string Value { get; set; }
    }
}
