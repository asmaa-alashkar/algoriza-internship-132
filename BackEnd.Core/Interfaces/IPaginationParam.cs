using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Core.Interfaces
{
    public interface IPaginationParam
    {
        int pageNumber { get; set; }
        int PageSize { get; set; }

        string filterValue { get; set; }
        string filterType { get; set; }


        string sortType { get; set; }
    }
}
