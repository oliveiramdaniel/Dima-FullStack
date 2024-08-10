using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Requests.Account
{
    public class LoginRequest : Request
    {
        [Required(ErrorMessage = "E-mail")]
        [EmailAddress(ErrorMessage = "Invalid E-mail")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Invalid Password")]
        public string Password { get; set; } = string.Empty;
    }
}
