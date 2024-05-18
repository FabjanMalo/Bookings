using Bookings.Domain.Apartments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Apartments.GetAll;
public class ApartmentDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Address { get; init; }
    public string Description { get;  init; }
}
