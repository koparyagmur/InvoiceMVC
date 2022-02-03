using System;
using System.ComponentModel.DataAnnotations;

namespace InvoinceProject.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        //[Range(2, 10, ErrorMessage = "Please use min 2 and max 100 character")]
        public string ProductCode { get; set; }

        //[Range(2, 100, ErrorMessage = "Please use min 2 and max 100 character")]
        public string ProductName { get; set; }

        [Required]
        //[RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Target Price; Maximum Two Decimal Points.")]
        public decimal UnitPrice { get; set; }

        //[Required(ErrorMessage = "Can not be null")]
        public int Quantity { get; set; }

        [Required]
        //[RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Target Price; Maximum Two Decimal Points.")]
        public decimal Amount { get; set; }
    }
}
