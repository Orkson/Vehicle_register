using System;
using System.Collections.Generic;

using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Vehicle
    {
        public int ID { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public int Mileage { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        private static void Main()
        {
            Execute().Wait();
        }

        public virtual ICollection<Enrollment> Enrollments { get; set; }

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