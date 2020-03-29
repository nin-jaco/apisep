using System;
using System.Globalization;

namespace ApiSep.Library.Extensions
{
    public static class DoubleExtensions
    {
        public static double ConvertCurrencyStringToDouble(this string currencyString)
        {
            if (double.TryParse(currencyString != "" ? currencyString : "R0,00", NumberStyles.Currency,
                        CultureInfo.GetCultureInfo("en-ZA"), out var currency))
            {
                return currency;
            }
            return 0;
        }

        public static double ConvertToDouble(this string amount)
        {
            return string.IsNullOrEmpty(amount) ? 0 : Convert.ToDouble(amount);
        }

        public static double ConvertToDoubleInvariant(this string amount)
        {
            if (!double.TryParse(amount, NumberStyles.Number | NumberStyles.AllowCurrencySymbol, CultureInfo.InvariantCulture, out _)) return 0;
            return string.IsNullOrEmpty(amount) ? 0 : double.Parse(amount, CultureInfo.InvariantCulture);
        }

        
    }//class
}
