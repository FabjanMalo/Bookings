using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Owners.Update;
public class UpdateOwnerCommand : IRequest<Guid>
{
    public UpdateOwnerDto UpdateOwnerDto { get; set; }
}
