using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Apartments.Delete;
public class DeleteApartmentCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
}
