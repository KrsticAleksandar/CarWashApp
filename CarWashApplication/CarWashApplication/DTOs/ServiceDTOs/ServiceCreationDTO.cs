using System.ComponentModel.DataAnnotations;

namespace CarWashApp.DTOs.ServiceDTOs
{
    public class ServiceCreationDTO
    {
        public string ServiceType { get; set; }
        public float Price { get; set; }
        public int Duration { get; set; }
    }
}
