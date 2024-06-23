using Bookings.Domain.Apartments;
using Bookings.Domain.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Domain.Bookings;
public class BookingEntity
{
    [Key]
    public Guid Id { get; set; }

    [ForeignKey(nameof(Apartment))]
    public Guid ApartmentId { get; private set; }
    public Apartment Apartments { get; private set; }

    [ForeignKey(nameof(User))]
    public Guid UserId { get; private set; }
    public User Users { get; private set; }

    public DateOnly Start { get; private set; }
    public DateOnly End { get; private set; }
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
}
