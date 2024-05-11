using Bookings.Domain.Apartments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Apartments;
public class ApartmentDto
{
    public string Name { get; private set; }
    public string Address { get; private set; }
    public decimal Price { get; private set; }
    public string Description { get; private set; }
    public decimal CleaningFee { get; private set; }
    public List<Amenity> Amenities { get; private set; } = new();
}
