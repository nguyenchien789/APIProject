using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class PagingModel
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public PagingModel()
        {
            PageNumber = 1;
            PageSize = 10;
        }

        public PagingModel(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}

