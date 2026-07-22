using Application.Abstractions;
using Application.Models.Requests;
using Application.Models.Responses;
using Domain.Entity;
using Domain.Enums;
using Infrastructure.Database;

namespace Infrastructure.Services;

public class FlightService(ApplicationContext dbContext) : IFlightService
{
    public ApplicationContext DbContext { get; set; } = dbContext;
    
    public bool CreateFlight(CreateFlightRequest request)
    {
        var newFlight = new Flight()
        {
            Code = request.Code,
            OriginAirportId = request.OriginAirportId,
            DestinationAirportId = request.DestinationAirportId,
            DepartureUtc = request.DepartureUtc,
            ArrivalUtc = request.ArrivalUtc,
            Status = request.Status,
            BasePrice = request.BasePrice,
        };
        
        dbContext.Flights.Add(newFlight);
        dbContext.SaveChanges();
        return true;
    }

    public bool UpdateFlight(Guid flightId, FlightStatus status)
    {
        var flight = dbContext.Flights.FirstOrDefault(x => x.Id == flightId);
        
        if(flight == null)
            return false;
        
        flight.Status = status;
        dbContext.SaveChanges();
        return true;
    }

    public List<GetFlightResponse> GetFlights(string? origin, string? destination, DateOnly? departureDate, DateOnly? arrivalDate,
        FlightStatus? status, int? page, int? pageSize)
    {
        var originalAirportInfo = dbContext.Airports.FirstOrDefault(x => x.Name == origin);
        var destinationAirportInfo = dbContext.Airports.FirstOrDefault(x => x.Name == destination);
        var flights = dbContext.Flights.Where(x => x.OriginAirportId == originalAirportInfo.Id && x.DestinationAirportId == destinationAirportInfo.Id && DateOnly.FromDateTime(x.DepartureUtc.LocalDateTime) == departureDate && DateOnly.FromDateTime(x.ArrivalUtc.LocalDateTime) == arrivalDate);

        var response = flights.Select(x => new GetFlightResponse()
        {
            Code = x.Code,
            OriginAirportName = originalAirportInfo.Name,
            DestinationAirportName = destinationAirportInfo.Name,
            ArrivalUtc = x.ArrivalUtc,
            DepartureUtc = x.DepartureUtc,
            Status = x.Status,
            BasePrice = x.BasePrice,
        }).ToList();
        
        return response;
    }

    public GetFlightResponse GetFlight(Guid flightId)
    {
        var dbResul = dbContext.Flights.FirstOrDefault(x => x.Id == flightId);
        var originalAirportInfo = dbContext.Airports.FirstOrDefault(x=>x.Id == dbResul.OriginAirportId);
        var destinationAirportInfo = dbContext.Airports.FirstOrDefault(x => x.Id == dbResul.DestinationAirportId);
        
        var response = new GetFlightResponse()
        {
            Code = dbResul.Code,
            OriginAirportName =  originalAirportInfo?.Name,
            DestinationAirportName = destinationAirportInfo?.Name,
            DepartureUtc = dbResul.DepartureUtc,
            ArrivalUtc = dbResul.ArrivalUtc,
            Status = dbResul.Status,
            BasePrice =  dbResul.BasePrice,
        };

        return response;
    }
}