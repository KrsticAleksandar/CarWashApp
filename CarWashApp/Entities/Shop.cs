namespace CarWashApp.Entities
{
    public class Shop
    {

        public int ShopId { get; set; }
        public string ShopName { get; set; }
        public int OpeningTime { get; set; }
        public int ClosingTime { get; set; }
        public string Address { get; set; }
        public string OwnerId { get; set; }
        public GeneralUser Owner { get; set; }
        public List<Reservation> Reservations { get; set; }
        public List<ShopsServices> ShopServices { get; set; }
    }
}
