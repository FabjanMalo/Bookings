using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Mail;
public interface IEmailSender
{
    Task<bool> SendEmail(Email email);
}
