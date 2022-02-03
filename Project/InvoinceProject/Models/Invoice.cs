using System;
using System.ComponentModel.DataAnnotations;

namespace InvoinceProject.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Product Code")]
        public string ProductCode { get; set; }

        [Required(ErrorMessage ="Please Enter Product Name")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Please Enter Unit Price")]
        public decimal UnitPrice { get; set; }

        [Required(ErrorMessage = "Please Enter Product Qty")]
        public int Quantity { get; set; }

        public decimal Amount { get; set; }
    }
}
