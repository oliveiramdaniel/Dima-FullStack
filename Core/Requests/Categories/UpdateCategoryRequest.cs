using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Requests.Categories
{
    //This category will be use on Api and UI
    public class UpdateCategoryRequest : Request
    {
        [Required(ErrorMessage = "Invalid Title")]
        [MaxLength(80, ErrorMessage = "Title must be up to 80 characters")]
        public string Title { get; set; } = string.Empty;
        [Required(ErrorMessage = "Invalid Description")]
        public string Description { get; set; } = string.Empty;
    }
}
