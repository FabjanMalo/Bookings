using Bookings.Domain.Apartments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Domain.ApartmentOwners;
public class ApartmentOwner
{


    public ApartmentOwner(Guid id, string firstName, string lastName, string phoneNumber, string identityCardNumber, string email, string password, DateTime createdOnUtc)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        PhoneNumber = phoneNumber;
        IdentityCardNumber = identityCardNumber;
        Email = email;
        Password = password;
        CreatedOnUtc = createdOnUtc;
    }

    [Key]
    public Guid Id { get; private set; }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string PhoneNumber { get; private set; }
    public string IdentityCardNumber { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public DateTime CreatedOnUtc { get; private set; }

    public List<Apartment> Apartments { get; } = [];

    public static ApartmentOwner CreateOwner(CreateApartmentOwnerDto ownerDto, List<Apartment> apartments)
    {

        var id = Guid.NewGuid();

        var createdOnUtc = DateTime.UtcNow;

        var apartmentOwner = new ApartmentOwner(id, ownerDto.FirstName, ownerDto.LastName, ownerDto.PhoneNumber, ownerDto.IdentityCardNumber, ownerDto.Email, ownerDto.Password, createdOnUtc);

        apartmentOwner.Apartments.AddRange(apartments);

        return apartmentOwner;

    }
}
