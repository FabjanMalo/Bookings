using Bookings.Application.Abstractions.Database;
using Bookings.Application.Apartments.Update;
using Bookings.Application.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Apartments.Delete;
public class DeleteApartmentCommandHandler(
    IApplicationContext _applicationContext,
    IApartmentRepository _apartmentRepository)
    : IRequestHandler<DeleteApartmentCommand, Guid>
{
    public async Task<Guid> Handle(DeleteApartmentCommand request, CancellationToken cancellationToken)
    {
        var apartment = await _applicationContext
             .Apartments
             .Where(x => x.Id == request.Id)
             .FirstOrDefaultAsync(cancellationToken);

        if (apartment == null)
        {
            throw new NotFoundException(nameof(apartment), request.Id);
        }

        _apartmentRepository.Delete(apartment);

        return apartment.Id;
    }
}
