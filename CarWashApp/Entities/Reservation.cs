using System.ComponentModel.DataAnnotations;

namespace CarWashApp.Entities
{
    public class Reservation
    {
        public int ReservationId { get; set; }

        
        public DateTime ReservationDateTime { get; set; }
        public bool Status { get; set; } = true;

        public string? ConsumerId { get; set; }
        public GeneralUser? Consumer { get; set; }
        public int ShopId { get; set; }
        public Shop Shop { get; set; }

        public int ServiceId { get; set; }
        public Service Service { get; set; }       
    }
}
