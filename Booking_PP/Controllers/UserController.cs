using Microsoft.AspNetCore.Mvc;
using Booking_PP.Models;

namespace Booking_PP.Controllers
{
    [Route("User")]
    public class UserController : Controller
    {
        private readonly ApplicationContext db;

        public UserController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet("TableOfBooking")]
        public IActionResult TableOfBooking()
        {
            return View(db.Rooms.OrderBy(x => x.NumberRoom).ToList());
        }

        [HttpGet("Booking")]
        public IActionResult Booking(int id)
        {
            return View(id);
        }

        [HttpPost("Booking")]
        public IActionResult Booking([FromForm] string? userFirstName, [FromForm] string? userSecondName, [FromForm] string? userPhoneNumber, [FromForm] int id)
        {
            var newUser = new User() { UserFirstName = userFirstName, UserSecondName = userSecondName, UserPhoneNumber = userPhoneNumber };
            var bookingRoom = db.Rooms.Where(x => x.ID == id).FirstOrDefault();
            if (bookingRoom != null && bookingRoom.IsFree == true)
            {
                bookingRoom.IsFree = false;

                var oldUser = db.Users.Where(x => x.UserPhoneNumber == newUser.UserPhoneNumber).FirstOrDefault();
                if (oldUser == null)
                {
                    newUser.Rooms.Add(bookingRoom);
                    db.Users.Add(newUser);
                }
                else
                {
                    oldUser.Rooms.Add(bookingRoom);
                }
                db.SaveChanges();
            }

            return RedirectToAction("TableOfBooking");
        }
    }
}
