namespace CarWashApp.Entities
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string ServiceType { get; set; }
        public float Price { get; set; }
        public int Duration { get; set; }

        public List<Reservation> Reservations { get; set; }

        public List<ShopsServices> ShopServices { get; set; }
    }
}
