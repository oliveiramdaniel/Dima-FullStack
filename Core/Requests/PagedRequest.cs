using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Requests
{
    //Check the Number of page
    public abstract class PagedRequest : Request
    {
        public int PageNumber { get; set; } = Configuration.PageNumber;
        public int PageSize { get; set; } = Configuration.DefaultPageSize;
    }
}
