using Bookings.Application.Abstractions.Database;
using Bookings.Domain.Apartments;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Apartments.Create;
public class CreateApartmentCommandHandler(
    IApplicationContext applicationContext,
    IApartmentRepository apartmentRepository)
    : IRequestHandler<CreateApartmentCommand, Guid>
{
    public async Task<Guid> Handle(CreateApartmentCommand request, CancellationToken cancellationToken)
    {
        var apartment = Apartment.Create(request.CreateApartmentDto);

        apartmentRepository.Add(apartment);

        await applicationContext.SaveChangesAsync(cancellationToken);

        return apartment.Id;
    }
}
