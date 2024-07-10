﻿using Bookings.Domain.Bookings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Domain.Reviews;
public class Review
{
    public Review(Guid id, Guid bookingId, int rating, string? comment, DateTime createdOnUtc)
    {
        Id = id;
        BookingId = bookingId;
        Rating = rating;
        Comment = comment;
        CreatedOnUtc = createdOnUtc;
    }

    [Key]
    public Guid Id { get; set; }

    [ForeignKey(nameof(BookingEntity))]
    public Guid BookingId { get; private set; }
    public BookingEntity Booking { get; set; }

    public int Rating { get; private set; }
    public string? Comment { get; private set; }
    public DateTime CreatedOnUtc { get; private set; }

    public static Review CreateReview(CreateReviewDto reviewDto)
    {
        var id = Guid.NewGuid();

        var createdOnUtc = DateTime.UtcNow;

        return new Review(id, reviewDto.BookingId, reviewDto.Rating, reviewDto.Comment, createdOnUtc);
    }
}
