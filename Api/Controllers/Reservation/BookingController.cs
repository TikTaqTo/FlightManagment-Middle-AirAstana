using Application.Models.Requests;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Reservation;

[ApiController]
public class BookingController : ControllerBase
{
    // /api/bookings?flightId=... — фильтрация по рейсу/статусу/датам
    [Authorize]
    [HttpGet("/api/bookings")]
    public IActionResult GetBookings([FromQuery] Guid? flightId,
        [FromQuery] BookingStatus bookingStatus,
        [FromQuery] DateTime bookingDate)
    {
        return Ok();
    }
    
    // GET /api/bookings/{id}
    [Authorize]
    [HttpGet("/api/bookings/{id}")]
    public IActionResult GetBooking([FromQuery] Guid? id)
    {
        return Ok();
    }
    
    // POST /api/bookings — создание
    [Authorize]
    [HttpPost("/api/bookings")]
    public IActionResult CreateAirport(CreateBookingRequest request)
    {
        return Ok();
    }
    
    // Patch /api/bookings/{id}/status - Изменить статус
    [Authorize]
    [HttpPatch("/api/bookings/{id}/status")]
    public IActionResult UpdateAirport(BookingStatus status)
    {
        return Ok();
    }
}