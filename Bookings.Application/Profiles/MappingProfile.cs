using AutoMapper;
using Bookings.Application.Apartments.Get;
using Bookings.Application.Apartments.GetAll;
using Bookings.Application.Bookings;
using Bookings.Application.Users.ChangePassword;
using Bookings.Domain.Apartments;
using Bookings.Domain.Bookings;
using Bookings.Domain.Reviews;
using Bookings.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Profiles;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Apartment, ApartmentDto>().ReverseMap();

        CreateMap<Apartment, ApartmentDetailDto>().ReverseMap();

        CreateMap<Apartment, CreateApartmentDto>().ReverseMap();


        CreateMap<User, UserDto>().ReverseMap();

        CreateMap<User, ChangePasswordUserDto>().ReverseMap();


        CreateMap<BookingEntity, CreateBookingDto>().ReverseMap();

        CreateMap<BookingEntity, BookingDto>().ReverseMap();


        CreateMap<Review, CreateReviewDto>().ReverseMap();


    }
}
