using Application.Models.Requests;
using Application.Models.Responses;
using Domain.Enums;

namespace Application.Abstractions;

public interface IFlightService
{
    public bool CreateFlight(CreateFlightRequest request);
    public bool UpdateFlight(Guid flightId, FlightStatus status);
    public List<GetFlightResponse> GetFlights(string? origin, string? destination, DateOnly? departureDate, DateOnly? arrivalDate, FlightStatus? status, int? page, int? pageSize);
    public GetFlightResponse GetFlight(Guid flightId);
}