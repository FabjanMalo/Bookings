using Bookings.Domain.Apartments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Apartments.GetAll;
public class ApartmentDto
{
    public Guid Id { get; set; }
    public string Name { get; private set; }
    public string Address { get; private set; }
    public string Description { get; private set; }
}
