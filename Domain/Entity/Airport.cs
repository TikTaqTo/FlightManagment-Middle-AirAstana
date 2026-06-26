namespace Domain.Entity;

public class Airport
{
    public Guid Id { get; set; }
    public string Iata { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
}
    