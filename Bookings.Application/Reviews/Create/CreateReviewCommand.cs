using Bookings.Domain.Reviews;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Reviews.Create;
public record CreateReviewCommand : IRequest<Guid>
{
    public CreateReviewDto CreateReviewDto { get; set; }
}
