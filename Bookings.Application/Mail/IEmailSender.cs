using Bookings.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Mail;
public interface IEmailSender
{
    Task<bool> SendEmail(User user, DateTime startDate, DateTime endDate);
}
