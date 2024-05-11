using Bookings.Domain.Apartments;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Apartments.GetAll;
public class GetAllApartmentsQuery : IRequest<List<ApartmentDto>>
{
}
