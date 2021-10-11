using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Application.Pagination
{
    public class PageResponse<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public T Data { get; set; }

        public PageResponse(T data, int pageNumber, int pageSize, int totalRecords)
        {
            int totalPage = totalRecords / pageSize;
            this.TotalPages = (totalRecords % pageSize) != 0 ? totalPage + 1 : totalPage;
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.TotalRecords = totalRecords;
            this.Data = data;
        }
    }
}
