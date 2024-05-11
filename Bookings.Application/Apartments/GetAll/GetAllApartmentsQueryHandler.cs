using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bookings.Application.Abstractions.Database;
using Bookings.Domain.Apartments;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Apartments.GetAll;
public class GetAllApartmentsQueryHandler(
    IApplicationContext _applicationContext,
    IMapper _mapper)
    : IRequestHandler<GetAllApartmentsQuery, List<ApartmentDto>>
{
    public async Task<List<ApartmentDto>> Handle(GetAllApartmentsQuery request, CancellationToken cancellationToken)
    {
        var apartments = await _applicationContext
            .Apartments
            .ProjectTo<ApartmentDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return apartments;
    }
}
