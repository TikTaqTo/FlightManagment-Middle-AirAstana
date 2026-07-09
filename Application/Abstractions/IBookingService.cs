using Application.Models.Requests;
using Application.Models.Responses;
using Domain.Enums;

namespace Application.Abstractions;

public interface IBookingService
{
    public bool CreateBooking(CreateBookingRequest request);
    public bool UpdateBooking(UpdateBookingRequest request);
    public List<GetBookingsResponse> GetBookings(Guid flightId, BookingStatus status, DateTime bookingDate);
    public GetBookingsResponse GetBooking(Guid id);
}