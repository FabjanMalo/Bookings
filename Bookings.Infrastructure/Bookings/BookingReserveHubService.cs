using Bookings.Application.Bookings.Create;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Infrastructure.Bookings;
public class BookingReserveHubService : IBookingReserveHubService
{
    private readonly IHubContext<BookingReserveHub, IBookingReserveHub> _hubContext;

    public BookingReserveHubService(IHubContext<BookingReserveHub, IBookingReserveHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task SendMessageToAllClients(string message)
    {
        await _hubContext.Clients.All.ReceiveMessage(message);
    }
}

