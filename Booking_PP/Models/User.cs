namespace Booking_PP.Models
{
    public class User
    {
        public int ID { get; set; }
        public string? UserFirstName { get; set; }
        public string? UserSecondName { get; set; }
        public string? UserPhoneNumber { get; set; }

        public List<Room> Rooms{ get; set; } = new();
    }
}
