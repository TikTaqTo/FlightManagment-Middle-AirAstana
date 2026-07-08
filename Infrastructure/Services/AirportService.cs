using Application.Abstractions;
using Application.Models.Requests;
using Application.Models.Responses;
using Domain.Entity;
using Infrastructure.Database;

namespace Infrastructure.Services;

public class AirportService(ApplicationContext dbContext) : IAirportService
{
    public bool CreateAirport(CreateAirportRequest request)
    {
        dbContext.Airports.Add(new Airport()
        {
            Name =  request.Name,
            Iata =  request.Iata,
            City = request.City,
            Country = request.Country
        });
        
        dbContext.SaveChanges();
        return true;
    }

    public bool UpdateAirport(Guid airportId, UpdateAirportRequest request)
    {
        var airport = dbContext.Airports.FirstOrDefault(x => x.Id == airportId);

        if (airport == null)
            return false;
        
        airport.City = request.City;
        airport.Country = request.Country;
        airport.Name = request.Name;
        airport.Iata = request.Iata;
        
        dbContext.SaveChanges();
        return true;
    }

    public bool DeleteAirport(Guid airportId)
    {
        var delAirport = dbContext.Airports.FirstOrDefault(x => x.Id == airportId);
        
        if (delAirport == null)
            return false;

        dbContext.Airports.Remove(delAirport);
        dbContext.SaveChanges();
        return true;
    }

    public List<GetAirportResponse> GetAirport(string query, int skip, int take)
    {
        var dbResul = dbContext.Airports.Where(x=> x.Iata == query || x.Name == query || x.City == query).Skip(skip).Take(take);
        var response = dbResul.Select(x => new GetAirportResponse()
        {
            Iata = x.Iata,
            Name = x.Name,
            Country = x.Country,
            City = x.City,
        }).ToList();

        return response;
    }
}