using Bookings.Application.Abstractions.Database;
using Bookings.Application.Reviews;
using Bookings.Domain.Reviews;
using Bookings.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Infrastructure.Reviews;
public class ReviewRepository : GenericRepository<Review>, IReviewRepository
{
    private readonly BookingsDbContext _dbContext;

    public ReviewRepository(BookingsDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
