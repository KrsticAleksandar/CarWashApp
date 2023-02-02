using CarWashApp.DTOs.ReservationDTOs;

namespace CarWashApp.DTOs.FilterDTO
{
    public class FilterDTO
    {
        public List<ReservationDTO> UpcomingDayReservations { get; set; }
        public List<ReservationDTO> CurrentDayReservations { get; set; }
    }
}
