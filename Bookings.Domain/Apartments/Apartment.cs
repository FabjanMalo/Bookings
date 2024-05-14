using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Domain.Apartments;
public class Apartment
{

    public Apartment(Guid id, string name, string address, decimal price, string description,
     decimal cleaningFee, List<Amenity> amenities)
    {
        Id = id;
        Name = name;
        Address = address;
        Price = price;
        Description = description;
        CleaningFee = cleaningFee;
        Amenities = amenities;
    }

    [Key]
    public Guid Id { get; set; }
    public string Name { get; private set; }
    public string Address { get; private set; }
    public decimal Price { get; private set; }
    public string Description { get; private set; }
    public decimal CleaningFee { get; private set; }
    public DateTime? LastBookedOnUtc { get; private set; }

    public List<Amenity> Amenities { get; private set; } = new();

    public static Apartment Create(CreateApartmentDto apartmentDto)
    {
        var id = new Guid();

        return new Apartment(id, apartmentDto.Name, apartmentDto.Address, apartmentDto.Price,
            apartmentDto.Description, apartmentDto.CleaningFee, apartmentDto.Amenities);
    }
}
