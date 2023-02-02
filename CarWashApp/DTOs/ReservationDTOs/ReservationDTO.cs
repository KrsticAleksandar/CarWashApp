namespace CarWashApp.DTOs.ReservationDTOs
{
    public class ReservationDTO
    {
        public DateTime ReservationDateTime { get; set; }
        public bool Status { get; set; } 

        public string? ConsumerId { get; set; }
    }
}
