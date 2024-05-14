using Bookings.Application.Contracts;
using Bookings.Domain.Apartments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Apartments;
public interface IApartmentRepository : IGenericRepository<Apartment>
{

}
