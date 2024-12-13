using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.Models
{
    public class UserForm
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public int MobileNumber { get; set; }


    }
}
