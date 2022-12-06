namespace Movars.Core.Helpers
{
    public static class Generator
    {
        public static string Reference()
        {
            var length = 10;
            var chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var result = string.Empty;
            Random random = new Random();
            for (var i = length; i > 0; --i) 
                result += chars[random.Next(0, chars.Length - 1)];
            return result;
        }
    }
}
