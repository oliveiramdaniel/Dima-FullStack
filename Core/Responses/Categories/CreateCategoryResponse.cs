﻿using Core.Models;
using Core.Responses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Requests.Categories
{
    //This category will be use on Api and UI
    public class CreateCategoryResponse : Response<Category>
    {
        public CreateCategoryResponse(Category? data, int code, string? message) : base(data, code, message) 
        { 
        
        }

    }
}
