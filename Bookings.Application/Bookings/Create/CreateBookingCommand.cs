using Bookings.Domain.Bookings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Bookings.Create;
public class CreateBookingCommand : IRequest<Guid>
{
    public CreateBookingDto CreateBookingDto { get; set; }
}
