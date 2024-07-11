using Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Requests.Transactions
{
    public class CreateTransactionRequest : Request
    {
        [Required(ErrorMessage = "Invalid Title")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Invalid Type")]
        public ETransactionType Type { get; set; }
        
        [Required(ErrorMessage = "Invalid Amount")]
        public decimal Amount { get; set; }
        
        [Required(ErrorMessage = "Invalid Type")]
        public long CategoryId { get; set; }

        [Required(ErrorMessage = "Invalid Type")]
        public DateTime? PaidOrReceiveAt { get; set; }
    }
}
