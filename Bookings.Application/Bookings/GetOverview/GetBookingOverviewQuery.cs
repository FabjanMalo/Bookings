using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Bookings.GetOverview;
public class GetBookingOverviewQuery : IRequest<List<GetBookingOverviewDto>>
{
    public SearchBookingDto SearchBookingDto { get; set; }
}
