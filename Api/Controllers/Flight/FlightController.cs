using System.Security.Claims;
using Application.Abstractions;
using Application.Models.Requests;
using Domain.Enums;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Flight;

public class FlightController(IFlightService flightService) : Controller
{
    public IFlightService FlightService { get; } = flightService;

    // GET /api/flights?origin=ALA&destination=TSE&dateFrom=2025-08-22&dateTo=2025-08-23&status=Scheduled&page=1& — фильтрация по рейсу/статусу/датам
    [Authorize]
    [HttpGet("/api/flights")]
    public IActionResult GetFlights(string? origin,
        string? destination,
        DateOnly? departureDate,
        DateOnly? arrivalDate,
        FlightStatus? status,
        int? page,
        int? pageSize)
    {
        return Ok(FlightService.GetFlights(destination, destination, departureDate, arrivalDate, status, page, pageSize));
    }
    
    // GET /api/flight/{id}
    [Authorize]
    [HttpGet("/api/flight/{id}")]
    public IActionResult GetFlight([FromQuery] Guid id)
    {
        return Ok(FlightService.GetFlight(id));
    }
    
    // POST /api/flights — создание
    [Authorize]
    [HttpPost("/api/flights")]
    public IActionResult CreateFlight(CreateFlightRequest request)
    {
        return Ok(FlightService.CreateFlight(request));
    }
    
    // Patch /api/flight/{id}/status - Изменить статус
    [Authorize]
    [HttpPatch("/api/flight/{id}/status")]
    public IActionResult UpdateBooking(Guid id, [FromBody] FlightStatus status)
    {
        return Ok(FlightService.UpdateFlight(id, status));
    }
}