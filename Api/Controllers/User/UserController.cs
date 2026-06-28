using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.User;

[ApiController]
public class UserController : Controller
{
    // POST /api/auth/login
    [HttpPost("/api/auth/login")]
    public IActionResult Index()
    {
        return View();
    }
}