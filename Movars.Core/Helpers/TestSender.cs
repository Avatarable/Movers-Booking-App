using SendGrid.Helpers.Mail;
using SendGrid;

namespace Movars.Core.Helpers
{
    public static class TestSender
    {
        public static async Task Execute(string apiKey)
        {
            //var apiKey = Environment.GetEnvironmentVariable("NAME_OF_THE_ENVIRONMENT_VARIABLE_FOR_YOUR_SENDGRID_KEY");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("able.nkanta@interswitchgroup.com", "Test User");
            var subject = "Sending with Interswitch";
            var to = new EmailAddress("ablenkanta@gmail.com", "Example User");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }

    public class AuthMessageSenderOptions
    {
        public string? SendGridKey { get; set; }
    }
}
