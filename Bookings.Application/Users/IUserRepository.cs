﻿using Bookings.Application.Contracts;
using Bookings.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Users;
public interface IUserRepository : IGenericRepository<User>
{
    Task<bool> IsEmailUnique(string email,CancellationToken cancellationToken);
}