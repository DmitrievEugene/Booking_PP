using Booking_PP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Booking_PP.Controllers
{
    [Route("Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationContext db;

        public AdminController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet("TableOfRooms")]
        public IActionResult TableOfRooms()
        {
            List<Room> rooms = db.Rooms.OrderBy(x => x.NumberRoom).Include(x => x.User).ToList();
            return View(rooms);
        }

        [HttpPost("TableOfRooms")]
        public IActionResult TableOfRooms(int id)
        {
            var deleteRoom = db.Rooms.Where(x => x.ID == id).FirstOrDefault();
            if (deleteRoom != null)
            {
                db.Rooms.Remove(deleteRoom);
                db.SaveChanges();
            }
            return RedirectToAction("TableOfRooms");
        }

        [HttpGet("CreateRoom")]
        public IActionResult CreateRoom()
        {
            return View();
        }

        [HttpPost("CreateRoom")]
        public IActionResult CreateRoom([FromForm] int? numberRoom, [FromForm] string? stringPriceRoom, [FromForm] string? descriptionRoom)
        {
            if (decimal.TryParse(stringPriceRoom, out decimal decimalPriceRoom))
            {
                var room = new Room() { NumberRoom = numberRoom, PriceRoom = decimalPriceRoom, DescriptionRoom = descriptionRoom };
                db.Rooms.Add(room);

                db.SaveChanges();
            }

            return RedirectToAction("TableOfRooms");
        }
    }
}
