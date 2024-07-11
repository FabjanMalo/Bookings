using Bookings.Domain.Apartments;
using Bookings.Domain.Reviews;
using Bookings.Domain.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Domain.Bookings;
public class BookingEntity
{
    public BookingEntity(Guid id,
                         Guid userId,
                         Guid apartmentId,
                         DateTime start,
                         DateTime end,
                         decimal priceForPeriod,
                         decimal cleaningFee,
                         decimal amenitiesUpCharge,
                         decimal totalPrice,
                         BookingStatus status,
                         DateTime createdOnUtc)
    {
        Id = id;
        UserId = userId;
        ApartmentId = apartmentId;
        Start = start;
        End = end;
        PriceForPeriod = priceForPeriod;
        CleaningFee = cleaningFee;
        AmenitiesUpCharge = amenitiesUpCharge;
        TotalPrice = totalPrice;
        Status = status;
        CreatedOnUtc = createdOnUtc;

    }

    [Key]
    public Guid Id { get; set; }

    [ForeignKey(nameof(Apartment))]
    public Guid ApartmentId { get; private set; }
    public Apartment Apartment { get; private set; }

    [ForeignKey(nameof(User))]
    public Guid UserId { get; private set; }
    public User User { get; private set; }

    public Review Review { get; private set; }

    public DateTime Start { get; private set; }
    public DateTime End { get; private set; }
    public decimal PriceForPeriod { get; private set; }
    public decimal CleaningFee { get; private set; }
    public decimal AmenitiesUpCharge { get; private set; }
    public decimal TotalPrice { get; private set; }
    public BookingStatus Status { get; private set; }
    public DateTime CreatedOnUtc { get; private set; }
    public DateTime? ConfirmedOnUtc { get; private set; }
    public DateTime? RejectedOnUtc { get; private set; }
    public DateTime? CompletedOnUtc { get; private set; }
    public DateTime? CancelledOnUtc { get; private set; }


    public void SetCompletedOnUtc(DateTime completedOnUtc, BookingStatus bookingStatus)
    {
        CompletedOnUtc = completedOnUtc;
        Status = bookingStatus;
    }
    public void SetRejectedOnUtc(DateTime rejectedOnUtc, BookingStatus bookingStatus)
    {
        RejectedOnUtc = rejectedOnUtc;
        Status = bookingStatus;
    }
    public void SetCancelledOnUtc(DateTime cancelledOnUtc, BookingStatus bookingStatus)
    {
        CancelledOnUtc = cancelledOnUtc;
        Status = bookingStatus;
    }

    public void SetConfirmedOnUtc(DateTime confirmedOnUtc, BookingStatus bookingStatus)
    {
        ConfirmedOnUtc = confirmedOnUtc;
        Status = bookingStatus;
    }
    public static BookingEntity CreateBooking(CreateBookingDto bookingDto,
        Apartment apartment, decimal amenitiesUpCharge)
    {
        var id = Guid.NewGuid();

        int days = (bookingDto.End.Day - bookingDto.Start.Day);

        decimal pricePerPeriod = apartment.Price * days;

        decimal cleaningFee = apartment.CleaningFee * days;

        decimal totalPrice = pricePerPeriod + cleaningFee + amenitiesUpCharge;

        DateTime date = DateTime.UtcNow;

        var status = BookingStatus.Reserved;

        return new BookingEntity(id,
                                 bookingDto.UserId,
                                 bookingDto.ApartmentId,
                                 bookingDto.Start,
                                 bookingDto.End,
                                 pricePerPeriod,
                                 cleaningFee,
                                 amenitiesUpCharge,
                                 totalPrice,
                                 status,
                                 date
                                 );
    }

}
