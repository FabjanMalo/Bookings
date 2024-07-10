using Bookings.Application.Abstractions.Database;
using Bookings.Application.Apartments.GetAll;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Bookings.GetOverview;
public class GetBookingOverviewQueryHandler(
    IApplicationContext _applicationContext)
    : IRequestHandler<GetBookingOverviewQuery, List<GetBookingOverviewDto>>
{
    public async Task<List<GetBookingOverviewDto>> Handle(GetBookingOverviewQuery request, CancellationToken cancellationToken)
    {

        var overview = _applicationContext
             .Bookings
             .Include(c => c.Apartment)
             .Include(c => c.User)
             .Include(c => c.Review)
             .Select(c => new GetBookingOverviewDto
             {
                 BookingId = c.Id,
                 FirstName = c.User.FirstName,
                 LastName = c.User.LastName,
                 ApartmentName = c.Apartment.Name,
                 ApartmentAddress = c.Apartment.Address,
                 ApartmentPrice = c.Apartment.Price,
                 ApartmentAmenities = c.Apartment.Amenities,
                 LastBookedOnUtc = c.Apartment.LastBookedOnUtc,
                 EndDate = c.End,
                 StartDate = c.Start,
                 TotalBookingPrice = c.TotalPrice,
                 BookingStatus = c.Status,
                 CreatedOnUtc = c.CreatedOnUtc,
                 ConfirmedOnUtc = c.ConfirmedOnUtc,
                 CancelledOnUtc = c.CancelledOnUtc,
                 RejectedOnUtc = c.RejectedOnUtc,
                 CompletedOnUtc = c.CompletedOnUtc,
                 Comment = c.Review.Comment,
                 Rating = c.Review.Rating

             });



        if (request.SearchBookingDto.StartDate != null && request.SearchBookingDto.EndDate != null)
        {
            if (request.SearchBookingDto.StartDate >= request.SearchBookingDto.EndDate)
            {
                throw new Exception("Start date must be earlier than end date.");
            }
            overview = overview
                 .Where(c => c.StartDate >= request.SearchBookingDto.StartDate
                 && c.EndDate <= request.SearchBookingDto.EndDate);
        }


        if (request.SearchBookingDto.SearchKey != null)
        {
            overview = overview
                 .Where(c => c.FirstName.Contains(request.SearchBookingDto.SearchKey)
                 || c.LastName.Contains(request.SearchBookingDto.SearchKey)
                 || c.ApartmentName.Contains(request.SearchBookingDto.SearchKey)
                 || c.ApartmentAddress.Contains(request.SearchBookingDto.SearchKey));

        }

        return await overview.ToListAsync(cancellationToken);
    }
}
