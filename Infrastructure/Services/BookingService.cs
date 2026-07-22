using Application.Abstractions;
using Application.Models.Requests;
using Application.Models.Responses;
using Domain.Entity;
using Domain.Enums;
using Infrastructure.Database;

namespace Infrastructure.Services;

public class BookingService(ApplicationContext dbContext) : IBookingService
{
    public ApplicationContext DbContext { get; set; } = dbContext;
    
    public bool CreateBooking(Guid userId, CreateBookingRequest request)
    {
        var flightResul = dbContext.Flights.FirstOrDefault(x => x.Id == request.FlightId);

        var dbResul = new Booking()
        {
            FlightId = request.FlightId,
            TotalPrice = flightResul.BasePrice * request.Passengers,
            PassengersCount = request.Passengers,
            UserId = userId,
            Status = BookingStatus.Created,
            CreatedAtUtc = DateTime.UtcNow,
        };
        
        dbContext.Bookings.Add(dbResul);
        
        dbContext.SaveChanges();
        return true;
    }

    public bool UpdateBooking(UpdateBookingRequest request)
    {
        var dbResul = dbContext.Bookings.FirstOrDefault(x => x.Id == request.BookingId);
        dbResul.Status = request.Status;
        
        return dbContext.SaveChanges() > 0;
    }

    public List<GetBookingsResponse> GetBookings(Guid? flightId, BookingStatus? status, DateTime? bookingDate)
    {
        var dbResul = dbContext.Bookings.Where(x => x.Id == flightId || x.Status == status || x.CreatedAtUtc == bookingDate);
        var response = dbResul.Select(x => new GetBookingsResponse()
        {
            Id =  x.Id,
            FlightId = x.FlightId,
            UserId =  x.UserId,
            PassengersCount = x.PassengersCount,
            TotalPrice = x.TotalPrice,
            Status =  x.Status,
            CreateAt = x.CreatedAtUtc.LocalDateTime
        }).ToList();

        return response;
    }

    public GetBookingsResponse GetBooking(Guid id)
    {
        var dbResul = dbContext.Bookings.FirstOrDefault(x => x.Id == id);
        var response = new GetBookingsResponse()
        {
            Id =  dbResul.Id,
            FlightId = dbResul.FlightId,
            UserId =  dbResul.UserId,
            PassengersCount =  dbResul.PassengersCount,
            TotalPrice = dbResul.TotalPrice,
            Status =  dbResul.Status,
            CreateAt = dbResul.CreatedAtUtc.LocalDateTime
        };

        return response;
    }
}