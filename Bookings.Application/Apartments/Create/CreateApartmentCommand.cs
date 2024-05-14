using Bookings.Domain.Apartments;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Apartments.Create;
public class CreateApartmentCommand : IRequest<Guid>
{
   public CreateApartmentDto CreateApartmentDto { get; set; }
}
