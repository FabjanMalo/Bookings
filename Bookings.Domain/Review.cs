using Bookings.Domain.Bookings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Domain;
public class Review
{
    [Key]
    public Guid Id { get; set; }

    [ForeignKey(nameof(BookingEntity))]
    public Guid BookingId { get; private set; }
    public BookingEntity Booking { get; set; }

    public int Rating { get; private set; }
    public string Comment { get; private set; }
    public DateTime CreatedOnUtc { get; private set; }
}
