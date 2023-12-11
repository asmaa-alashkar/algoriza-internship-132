using BackEnd.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.EF.Repositories
{
    public class PaginationParam:IPaginationParam
    {
        private const int MaxPageSize = 10000;
        public int pageNumber { get; set; } = 1;
        private int pageSize = 10;
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }

        public string filterValue { get; set; } = "";
        public string filterType { get; set; } = "";

        public string sortType { get; set; } = "";

    }
}
