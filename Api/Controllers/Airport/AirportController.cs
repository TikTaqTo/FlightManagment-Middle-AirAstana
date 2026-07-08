using Application.Abstractions;
using Application.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Airport;

[ApiController]
public class AirportController(IAirportService airportService) : ControllerBase
{
    // GET /api/airports?search=ala&page=1&size=20 — поиск по IATA/Name/City
    [HttpGet("/api/airports")]
    public IActionResult Index([FromQuery] string? search,
        [FromQuery] int page = 1,
        [FromQuery] int size = 20)
    {
        return Ok(airportService.GetAirport(search ?? "", page, size));
    }
    
    // POST /api/airports — создание
    [HttpPost("/api/airports")]
    public IActionResult CreateAirport(CreateAirportRequest request)
    {
        return Ok(airportService.CreateAirport(request));
    }
    
    // PUT /api/airports/{id}
    [HttpPut("/api/airports/{id}")]
    public IActionResult UpdateAirport(Guid id, UpdateAirportRequest request)
    {
        return Ok(airportService.UpdateAirport(id, request));
    }
    
    // DELETE /api/airports/{id} — удаление (жёсткое)
    [HttpDelete("/api/airports/{id}")]
    public IActionResult DeleteAirport(Guid id)
    {
        return Ok(airportService.DeleteAirport(id));
    }
}