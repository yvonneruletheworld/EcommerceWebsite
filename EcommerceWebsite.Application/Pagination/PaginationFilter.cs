using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Application.Pagination
{
    public class PaginationFilter
    { 
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public PaginationFilter(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public PaginationFilter()
        {
            this.PageNumber = 1;
            this.PageSize = 10;
        }
    }
}
