namespace Application.Models.Requests;

public class CreateAirportRequest
{
    public string Iata { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
}