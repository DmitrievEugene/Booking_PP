using Microsoft.AspNetCore.Mvc;

namespace Booking_PP.Controllers
{
    [Route("")]
    [Route("{controller}/{Index}")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
