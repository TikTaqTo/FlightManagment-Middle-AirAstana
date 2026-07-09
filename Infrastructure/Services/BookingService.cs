using Application.Abstractions;
using Application.Models.Requests;
using Application.Models.Responses;
using Domain.Enums;
using Infrastructure.Database;

namespace Infrastructure.Services;

public class BookingService(ApplicationContext dbContext) : IBookingService
{
    public ApplicationContext DbContext { get; set; } = dbContext;
    
    public bool CreateBooking(CreateBookingRequest request)
    {
        throw new NotImplementedException();
    }

    public bool UpdateBooking(UpdateBookingRequest request)
    {
        throw new NotImplementedException();
    }

    public List<GetBookingsResponse> GetBookings(Guid flightId, BookingStatus status, DateTime bookingDate)
    {
        throw new NotImplementedException();
    }

    public GetBookingsResponse GetBooking(Guid id)
    {
        throw new NotImplementedException();
    }
}