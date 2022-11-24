using System.ComponentModel.DataAnnotations;

namespace ADonnu.Models
{
    public class UserModel
    {
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
    }
}