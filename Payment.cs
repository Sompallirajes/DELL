using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.Models
{
    public class Payment
    {
        [Key]
        public string PaymentMode { get; set; }
        public decimal TotalAmount { get; set; }

        
    }
}
