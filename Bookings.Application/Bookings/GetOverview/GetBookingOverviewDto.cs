using Bookings.Domain.Apartments;
using Bookings.Domain.Bookings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Bookings.GetOverview;
public class GetBookingOverviewDto
{
    public Guid BookingId { get; init; }

    public string FirstName { get; init; }
    public string LastName { get; init; }

    public string ApartmentName { get; init; }
    public string ApartmentAddress { get; init; }
    public decimal ApartmentPrice { get; init; }
    public DateTime? LastBookedOnUtc { get; init; }
    public List<Amenity> ApartmentAmenities { get; init; } = [];

    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
    public decimal TotalBookingPrice { get; init; }
    public BookingStatus BookingStatus { get; init; }
    public DateTime CreatedOnUtc { get; init; }
    public DateTime? ConfirmedOnUtc { get; init; }
    public DateTime? RejectedOnUtc { get; init; }
    public DateTime? CompletedOnUtc { get; init; }
    public DateTime? CancelledOnUtc { get; init; }

    public int? Rating { get; init; }
    public string? Comment { get; init; }

}
