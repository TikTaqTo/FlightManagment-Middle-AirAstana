using Domain.Enums;

namespace Domain.Entity;

public class Booking
{
    public Guid Id { get; set; }
    public Guid FlightId { get; set; }
    public Guid UserId { get; set; }
    public int PassengersCount { get; set; }
    public decimal TotalPrice { get; set; }
    public BookingStatus Status { get; set; }
    public DateTimeOffset CreatedAtUtc { get; set; }
    public byte[] RowVersion { get; set; }
}