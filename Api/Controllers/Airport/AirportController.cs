using Application.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Airport;

public class AirportController : Controller
{
    // GET /api/airports?search=ala&page=1&size=20 — поиск по IATA/Name/City
    [HttpGet("/api/airports")]
    public IActionResult Index([FromQuery] string? search,
        [FromQuery] int page = 1,
        [FromQuery] int size = 20)
    {
        return View();
    }
    
    // POST /api/airports — создание
    [HttpPost("/api/airports")]
    public IActionResult Index2(CreateAirportRequest request)
    {
        return View();
    }
    
    // PUT /api/airports/{id}
    [HttpPut("/api/airports/{id}")]
    public IActionResult Index2(Guid id, UpdateAirportRequest request)
    {
        return View();
    }
    
    // DELETE /api/airports/{id} — удаление (жёсткое)
    [HttpDelete("/api/airports/{id}")]
    public IActionResult Index2(Guid id)
    {
        return View();
    }
}