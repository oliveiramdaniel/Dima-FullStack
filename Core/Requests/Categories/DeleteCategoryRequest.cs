using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Requests.Categories
{
    //This category will be use on Api and UI
    public class DeleteCategoryRequest : Request
    {
        public long id { get; set; }
    }
}
