using System.Globalization;

namespace ApiSep.Library.Extensions
{
    public static class DecimalExtensions
    {
        public static decimal ConvertToDecimalInvariant(this string amount)
        {
            if (!decimal.TryParse(amount, NumberStyles.Number | NumberStyles.AllowCurrencySymbol, CultureInfo.InvariantCulture, out _)) return 0;
            return string.IsNullOrEmpty(amount) ? 0 : decimal.Parse(amount, CultureInfo.InvariantCulture);
        }

        public static decimal ConvertCurrencyStringToDecimal(this string currencyString)
        {
            if (decimal.TryParse(currencyString != "" ? currencyString : "R0,00", NumberStyles.Currency,
                CultureInfo.GetCultureInfo("en-ZA"), out var currency))
            {
                return currency;
            }
            return 0;
        }
    }
}
