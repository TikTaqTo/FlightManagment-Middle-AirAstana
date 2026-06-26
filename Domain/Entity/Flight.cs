using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Domain.Entity;

public class Flight
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public Guid OriginAirportId { get; set; }
    public Guid DestinationAirportId { get; set; }
    public DateTimeOffset DepartureUtc { get; set; }
    public DateTimeOffset ArrivalUtc { get; set; }
    public FlightStatus Status { get; set; }
    public decimal BasePrice { get; set; }
    public byte[] RowVersion { get; set; }
}