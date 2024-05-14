using Bookings.Application.Apartments.GetAll;
using Bookings.Domain.Apartments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Apartments.Get;
public class ApartmentDetailDto : ApartmentDto
{
    public decimal Price { get; private set; }
    public decimal CleaningFee { get; private set; }

    public List<Amenity> Amenities { get; private set; } = new();
}
