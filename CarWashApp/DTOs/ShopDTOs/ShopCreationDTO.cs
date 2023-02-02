using System.ComponentModel.DataAnnotations;

namespace CarWashApp.DTOs
{
    public class ShopCreationDTO
    {
        public string ShopName { get; set; }
        public int OpeningTime { get; set; }
        public int ClosingTime { get; set; }
        public string Address { get; set; }
    }
}
