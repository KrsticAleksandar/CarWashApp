using System.ComponentModel.DataAnnotations;

namespace CarWashApp.DTOs.UserDTOs
{
    public class UserLogInDTO
    {
        [EmailAddress]
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
