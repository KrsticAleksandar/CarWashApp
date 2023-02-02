using Microsoft.AspNetCore.Identity;

namespace CarWashApp.Entities
{
    public class GeneralUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Shop> Shops { get; set; }
        public List<Reservation> Reservations { get; set; }    
    }
}



