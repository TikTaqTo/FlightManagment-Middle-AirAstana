namespace Application.Models.Requests;

public class CreateBookingRequest
{
    public Guid FlightId { get; set; }
    public int Passengers { get; set; } 
}