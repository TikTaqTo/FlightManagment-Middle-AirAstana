using Domain.Enums;

namespace Application.Models.Requests;

public class CreateFlightRequest
{
    public string Code { get; set; }
    public Guid OriginAirportId { get; set; }
    public Guid DestinationAirportId { get; set; }
    public DateTimeOffset DepartureUtc { get; set; }
    public DateTimeOffset ArrivalUtc { get; set; }
    public FlightStatus Status { get; set; }
    public decimal BasePrice { get; set; }
}