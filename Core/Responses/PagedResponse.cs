﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Responses
{
    public class PagedResponse<TData> : Response<TData>
    {
        [JsonConstructor]
        public PagedResponse(TData? data, int totalCount, int currentPage, int pageSize) :base(data)
        {
            Data = data;
            TotalCount = totalCount;
            CurrentPage = 1;
            PageSize = Configuration.DefaultPageSize;
        }

        public PagedResponse(TData? data, int code = Configuration.DefaultPageSize, string? message = null) : base(data, code, message)
        { 
        
        }
        public int CurrentPage {  get; set; }
        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
        public int PageSize { get; set; } = Configuration.DefaultPageSize;
        public int TotalCount { get; set; }
    }
}
