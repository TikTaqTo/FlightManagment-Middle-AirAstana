using Domain.Enums;

namespace Application.Models.Responses;

public class GetBookingsResponse
{
    public Guid Id { get; set; }
    public Guid FlightId { get; set; }
    public Guid UserId { get; set; }
    public int PassengersCount { get; set; }
    public decimal TotalPrice { get; set; }
    public BookingStatus Status { get; set; }
    public DateTime CreateAt { get; set; }
}