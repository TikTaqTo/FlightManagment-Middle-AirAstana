using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Flight;

public class FlightController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}