﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Requests.Categories
{
    public class GetCategoryByIdRequest : Request
    {
        public long id {  get; set; }
    }
}
