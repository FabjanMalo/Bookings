using Bookings.Application.Apartments.Get;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Apartments.Update;
public class UpdateApartmentCommand : IRequest<Guid>
{
    public ApartmentDetailDto ApartmentDetailDto { get; set; }
}
