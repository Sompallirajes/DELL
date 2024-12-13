using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.Models
{
    public class Login
    {
        [Key]
        public string UserName {  get; set; }
        public string Password { get; set; }
    }
}
