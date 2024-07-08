using Bookings.Application.Abstractions.Database;
using Bookings.Application.Contracts;
using Bookings.Domain.Reviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Reviews;
public interface IReviewRepository : IGenericRepository<Review>
{
}
