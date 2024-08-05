using Bookings.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Infrastructure.Contracts;
public class GenericRepository<T>(
    BookingsDbContext _dbContext)
    : IGenericRepository<T> where T : class
{
    public async Task<T> Add(T entity)
    {
        await _dbContext.AddAsync(entity);

        return entity;
    }

    public void Delete(T entity)
    {
        _dbContext.Set<T>().Remove(entity);

    }

    public void Update(T entity)
    {
        _dbContext.Set<T>().Update(entity);
    }
}
