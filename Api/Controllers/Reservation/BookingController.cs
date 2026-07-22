using System.Security.Claims;
using Application.Abstractions;
using Application.Models.Requests;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Reservation;

[ApiController]
public class BookingController(IBookingService bookingService) : ControllerBase
{
    public IBookingService BookingService { get; } = bookingService;

    // /api/bookings?flightId=... — фильтрация по рейсу/статусу/датам
    [Authorize]
    [HttpGet("/api/bookings")]
    public IActionResult GetBookings([FromQuery] Guid? flightId,
        [FromQuery] BookingStatus? bookingStatus,
        [FromQuery] DateTime? bookingDate)
    {
        return Ok(BookingService.GetBookings(flightId, bookingStatus, bookingDate));
    }
    
    // GET /api/bookings/{id}
    [Authorize]
    [HttpGet("/api/bookings/{id}")]
    public IActionResult GetBooking([FromQuery] Guid id)
    {
        return Ok(BookingService.GetBooking(id));
    }
    
    // POST /api/bookings — создание
    [Authorize]
    [HttpPost("/api/bookings")]
    public IActionResult CreateBooking(CreateBookingRequest request)
    {
        return Ok(BookingService.CreateBooking(Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!), request));
    }
    
    // Patch /api/bookings/{id}/status - Изменить статус
    [Authorize]
    [HttpPatch("/api/bookings/{id}/status")]
    public IActionResult UpdateBooking(Guid id, [FromBody] BookingStatus status)
    {
        return Ok(BookingService.UpdateBooking(new UpdateBookingRequest()
        {
            BookingId = id,
            Status = status
        }));
    }
}