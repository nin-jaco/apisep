namespace ApiSep.Library.Extensions
{
    public static class IntExtensions
    {
        public static int ToInt(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return 0;
            return int.TryParse(value, out var parsedInt) ? parsedInt : 0;
        }
    }
}
