using System.ComponentModel.DataAnnotations;

namespace CarWashApp.DTOs.UserDTOs
{
    public class UserInfo : UserLogInDTO
    {
        public bool IsOwner { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
