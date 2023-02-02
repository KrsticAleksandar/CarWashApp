using CarWashApp.Entities;

namespace CarWashApp.DTOs
{
    public class ShopDTO
    {
        public int ShopId { get; set; }
        public string ShopName { get; set; }
        public int OpeningTime { get; set; }
        public int ClosingTime { get; set; }
        public string Address { get; set; }
    }
}
