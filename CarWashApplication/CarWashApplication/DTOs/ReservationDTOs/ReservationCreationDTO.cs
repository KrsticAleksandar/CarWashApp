using System.ComponentModel.DataAnnotations;

namespace CarWashApp.DTOs.ReservationDTOs
{
    public class ReservationCreationDTO
    {
        public DateTime ReservationDateTime { get; set; }
        public int ServiceId { get; set; }
        public int ShopId { get; set; }
    }
}
