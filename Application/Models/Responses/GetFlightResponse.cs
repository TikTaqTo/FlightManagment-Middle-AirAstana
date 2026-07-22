using Domain.Enums;

namespace Application.Models.Responses;

public class GetFlightResponse
{
    public string Code { get; set; }
    public string OriginAirportName { get; set; }
    public string DestinationAirportName { get; set; }
    public DateTimeOffset DepartureUtc { get; set; }
    public DateTimeOffset ArrivalUtc { get; set; }
    public FlightStatus Status { get; set; }
    public decimal BasePrice { get; set; }
}