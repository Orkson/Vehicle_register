using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class SendGrid
    {
        static async Task Execute()
        {
            var apiKey = Environment.GetEnvironmentVariable("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");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("test@example.com", "Example User");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress("test@example.com", "Example User");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}