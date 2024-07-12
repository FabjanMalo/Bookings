using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Bookings.GetOverview;
public class SearchBookingDto
{
    public string? SearchKey { get; init; }
    public DateTime? StartDate { get; init; }
    public DateTime? EndDate { get; init; }

    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;

    public string? SortingColumnName { get; init; }
    public bool IsAscending { get; init; } = true;
}
