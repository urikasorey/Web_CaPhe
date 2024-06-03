using System.ComponentModel.DataAnnotations;
namespace Web_CaPhee2_api.Models
{
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
 