using AutoMapper;
using Bookings.Application.Apartments;
using Bookings.Application.DTOs.Users;
using Bookings.Domain;
using Bookings.Domain.Apartments;
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

        CreateMap<User, UserDto>().ReverseMap();

    }
}
