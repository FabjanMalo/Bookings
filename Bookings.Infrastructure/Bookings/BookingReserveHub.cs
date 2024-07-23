using Bookings.Application.Bookings;
using Bookings.Application.Bookings.Create;
using Bookings.Application.Contracts;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Infrastructure.Bookings;
public class BookingReserveHub : Hub<IBookingReserveHub>
{
    public async override Task OnConnectedAsync()
    {
        await Clients.All.ReceiveMessage($"{Context.ConnectionId} has joined");
    }
    
}
