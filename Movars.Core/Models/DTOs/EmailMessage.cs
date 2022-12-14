namespace Movars.Core.Models.DTOs
{
    public class EmailMessage
    {
        public ICollection<string> ToEmail { get; set; }
        public string Subject { get; set; }
        public string _template;
        public IDictionary<string, string> PlaceHolders { get; set; }
        public string PlainTextMessage { get; set; }
        public string Template
        {
            set { _template = value; }
            get { return ParseHtml(_template, PlainTextMessage, PlaceHolders); }
        }
        public EmailMessage()
        {
            ToEmail = new List<string>();
            PlaceHolders = new Dictionary<string, string>();
        }
        private static string ParseHtml(string template, string message, IDictionary<string, string> placeholders)
        {
            var path = $"/app/EmailTemplates/{template}.html";
            bool isDevelopment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";
            if (isDevelopment)
                path = $@"../Movars.Core/Commons/EmailTemplates/{template}.html";
            var htmlText = System.IO.File.ReadAllText(path);
            var result = "";
            foreach (var key in placeholders.Keys)
            {
                result = htmlText.Replace(key, placeholders[key]);
                htmlText = result;
            }
            return result;
        }
    }
}
