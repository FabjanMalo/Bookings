using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bookings.Application.Abstractions.Database;
using Bookings.Application.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Apartments.Get;
public class GetApartmentQueryHandler(
    IApplicationContext _applicationContext,
    IMapper _mapper)
    : IRequestHandler<GetApartmentQuery, ApartmentDetailDto>
{
    public async Task<ApartmentDetailDto> Handle(GetApartmentQuery request, CancellationToken cancellationToken)
    {
        var apartment = await _applicationContext
            .Apartments
            .Where(a => a.Id == request.Id)
            .ProjectTo<ApartmentDetailDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        if (apartment is null)
        {
            throw new NotFoundException(nameof(apartment), request.Id);
        }

        return apartment;
    }
}
