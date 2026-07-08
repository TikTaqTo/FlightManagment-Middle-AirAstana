using Application.Models.Requests;
using Application.Models.Responses;

namespace Application.Abstractions;

public interface IAirportService
{
    public bool CreateAirport(CreateAirportRequest request);
    public bool UpdateAirport(Guid airportId, UpdateAirportRequest request);
    public bool DeleteAirport(Guid airportId);
    public List<GetAirportResponse> GetAirport(string query, int skip, int take);
}