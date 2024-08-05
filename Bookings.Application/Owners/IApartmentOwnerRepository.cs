using Bookings.Application.Contracts;
using Bookings.Domain.ApartmentOwners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Owners;
public interface IApartmentOwnerRepository : IGenericRepository<ApartmentOwner>
{
    Task<bool> IsEmailUnique(string email, CancellationToken cancellationToken);
}
