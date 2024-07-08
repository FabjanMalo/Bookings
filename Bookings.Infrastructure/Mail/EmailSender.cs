using Bookings.Application.Mail;
using Bookings.Domain.Users;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic.FileIO;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Infrastructure.Mail;
public class EmailSender(
    IOptions<EmailSettings> settingsOptions,
    IOptions<Email> emailOptions)
    : IEmailSender
{
    private readonly EmailSettings _emailSettings = settingsOptions.Value;

    private readonly Email _email = emailOptions.Value;

    public async Task<bool> SendEmail(User user, DateTime startDate, DateTime endDate)
    {
        var client = new SendGridClient(_emailSettings.ApiKey);
        var to = new EmailAddress(user.Email);
        var from = new EmailAddress
        {
            Email = _emailSettings.FromAdress,
            Name = _emailSettings.FromName
        };

        var body = _email.Body.Replace("{startDate}", startDate.ToString())
            .Replace("{endDate}", endDate.ToString())
            .Replace("{firstName}", user.FirstName)
            .Replace("{lastName}", user.LastName);

        var mesagge = MailHelper.CreateSingleEmail(from, to, _email.Subject, body, body);


        var response = await client.SendEmailAsync(mesagge);

        return response.StatusCode == System.Net.HttpStatusCode.OK ||
            response.StatusCode == System.Net.HttpStatusCode.Accepted;
    }
}
