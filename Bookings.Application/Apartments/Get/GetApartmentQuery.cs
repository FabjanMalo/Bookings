using Bookings.Application.Apartments.GetAll;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Apartments.Get;
public class GetApartmentQuery : IRequest<ApartmentDetailDto>
{
    public Guid Id { get; set; }
}
