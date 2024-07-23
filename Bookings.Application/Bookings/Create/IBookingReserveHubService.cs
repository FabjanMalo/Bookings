﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Bookings.Create;
public interface IBookingReserveHubService
{
    public Task SendMessageToAllClients(string message);
}
