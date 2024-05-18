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
    public decimal Price { get; init; }
    public decimal CleaningFee { get; init; }

    public List<Amenity> Amenities { get; init; } = [];
}
