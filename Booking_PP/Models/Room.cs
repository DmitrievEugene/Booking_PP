namespace Booking_PP.Models
{
    public class Room
    {
        public int ID { get; set; }
        public int? NumberRoom { get; set; }
        public decimal? PriceRoom { get; set; }
        public string? DescriptionRoom { get; set; }
        public bool IsFree { get; set; } = true;

        public int? UserID { get; set; }
        public User? User { get; set; }
    }
}
