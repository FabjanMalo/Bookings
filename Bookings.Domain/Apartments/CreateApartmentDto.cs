using Bookings.Domain.Apartments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Domain.Apartments;
public class CreateApartmentDto
{
    public Guid OwnerId { get; set; }
    public string Name { get; init; }
    public string Address { get; init; }
    public decimal Price { get; init; }
    public string Description { get; init; }
    public decimal CleaningFee { get; init; }
    public List<Amenity> Amenities { get; init; } = [];

}
