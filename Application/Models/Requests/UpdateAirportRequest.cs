namespace Application.Models.Requests;

public class UpdateAirportRequest
{
    public string Name { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
}