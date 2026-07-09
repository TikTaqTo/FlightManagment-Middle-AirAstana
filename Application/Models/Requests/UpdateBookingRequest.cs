using Domain.Enums;

namespace Application.Models.Requests;

public class UpdateBookingRequest
{
    public Guid BookingId { get; set; }
    public BookingStatus Status { get; set; }
}