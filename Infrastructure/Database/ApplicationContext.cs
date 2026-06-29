using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Airport> Airports => Set<Airport>();
    public DbSet<Booking> Bookings => Set<Booking>();
    public DbSet<Flight> Flights => Set<Flight>();
    
    public ApplicationContext() => Database.EnsureCreated();
 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=FlightManager;Username=flightapp;Password=123456;");
    }
}