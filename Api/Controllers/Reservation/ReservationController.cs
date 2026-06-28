using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Reservation;

public class ReservationController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}