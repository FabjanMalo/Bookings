using Bookings.Domain.ApartmentOwners;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Owners.Create;
public class CreateOwnerCommand : IRequest<Guid>
{
    public CreateApartmentOwnerDto CreateApartmentOwnerDto { get; set; }
}
