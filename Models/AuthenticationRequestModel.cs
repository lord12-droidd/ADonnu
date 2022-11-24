using System.ComponentModel.DataAnnotations;

namespace ADonnu.Models
{
    public class AuthenticationRequestModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}