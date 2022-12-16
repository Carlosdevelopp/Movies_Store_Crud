namespace Infrastructure.Utils
{
    public static class Extensions
    {
        public static string FormatTitle(this string text)
        {
            if (text.Contains(""))
            {
                text = text.Replace(text, $"*{text}*");
            }

            return text;
        }

        public static string TextUpperCase(this string text)
        {
            if (text.Contains(""))
            {
                text = text.Replace(text, $"{text.ToUpper()}");
            }

            return text;
        }
    }
}
