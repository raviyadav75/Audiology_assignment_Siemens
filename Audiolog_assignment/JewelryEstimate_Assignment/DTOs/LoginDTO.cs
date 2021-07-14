using System.ComponentModel.DataAnnotations;

namespace JewelryEstimate_Assignment.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage="user name is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Password is required")]
        public string Password { get; set; }
    }
}
