using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ApiSep.Library.Extensions
{
    public static class StringExtensions
    {

        /// <summary>
        /// Try to get an integer from the string. returns 0 if failed.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int TryGetInt(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return 0;
            }

            int result = 0;
            int.TryParse(str, out result);
            return result;
        }

        public static string RemoveLastCharacter(this string instr)
        {
            return instr.Substring(0, instr.Length - 1);
        }
        public static string RemoveLast(this string instr, int number)
        {
            return instr.Substring(0, instr.Length - number);
        }
        public static string RemoveFirstCharacter(this string instr)
        {
            return instr.Substring(1);
        }
        public static string RemoveFirst(this string instr, int number)
        {
            return instr.Substring(number);
        }

        public static string NullToEmpty(this string instr)
        {
            return instr?.Trim() ?? string.Empty;
        }

        /// <summary>
        /// Returns a boolean value indicating whether the string is null or
        /// consists of only whitespace characters.
        /// </summary>
        /// <param name="instr">The string to check</param>
        /// <returns>true if the string is null or contains only whitespace characters</returns>
        public static bool IsNullOrWhitespace(this string instr)
        {
            return string.IsNullOrWhiteSpace(instr);
        }

        /// <summary>
        /// Returns a boolean value indicating whether the string is not null and does not
        /// consist of only whitespace characters.
        /// </summary>
        /// <param name="instr">The string to check</param>
        /// <returns>true if the string is not null and does not contain only whitespace characters</returns>
        public static bool NotNullOrWhitespace(this string instr)
        {
            return !string.IsNullOrWhiteSpace(instr);
        }

        public static string ConvertDoubleToCurrencyString(this double amount)
        {
            return amount.ToString("C", CultureInfo.GetCultureInfo("en-ZA"));
        }

        public static string ConvertDecimalToCurrencyString(this decimal amount)
        {
            return amount.ToString("C", CultureInfo.GetCultureInfo("en-ZA"));
        }

        public static string ConvertStringToCurrencyString(this string amount)
        {
            var correctString = !string.IsNullOrEmpty(amount) ? amount.Contains('.') ? amount.Replace('.', ',') : amount : "0";
            double test;
            return double.TryParse(correctString, NumberStyles.Currency, CultureInfo.GetCultureInfo("en-ZA"), out test)
                ? test.ToString("C", CultureInfo.GetCultureInfo("en-ZA"))
                : "R0,00";
        }

        public static string ToTitleCase(this string s)
        {
            return !string.IsNullOrWhiteSpace(s) ? CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s.ToLower()) : "";
        }

        public static T GetEnumFromDescription<T>(this string description)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                if (Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException("Not found.", nameof(description));
            // or return default(T);
        }

        public static string TruncateString(this string value, int maxLength)
        {
            return value?.Substring(0, Math.Min(value.Length, maxLength));
        }

        public static string BoolToYn(this bool boolean)
        {
            return boolean ? "Y" : "N";
        }

        public static string EncodeToUtf16(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return value;

            if (value.Contains(@"encoding=""ISO-8859-1"""))
            {
                value = value.Replace(@"encoding=""ISO-8859-1""", @"encoding=""utf-16""");
            }

            byte[] utf8Bytes = Encoding.UTF8.GetBytes(value);

            //Converting to Unicode from UTF8 bytes
            byte[] unicodeBytes = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, utf8Bytes);

            //Getting string from Unicode bytes
            return Encoding.Unicode.GetString(unicodeBytes);
        }

        public static string XmlEncodeToString(object source, Type type, Encoding encoding)
        {
            // The string to hold the object content
            String content;

            // Create a memoryStream into which the data can be written and readed
            using (var stream = new MemoryStream())
            {
                // Create the xml serializer, the serializer needs to know the type
                // of the object that will be serialized
                var xmlSerializer = new XmlSerializer(type);

                // Create a XmlTextWriter to write the xml object source, we are going
                // to define the encoding in the constructor
                using (var writer = new XmlTextWriter(stream, encoding))
                {
                    // Save the state of the object into the stream
                    xmlSerializer.Serialize(writer, source);

                    // Flush the stream
                    writer.Flush();

                    // Read the stream into a string
                    using (var reader = new StreamReader(stream, encoding))
                    {
                        // Set the stream position to the begin
                        stream.Position = 0;

                        // Read the stream into a string
                        content = reader.ReadToEnd();
                    }
                }
            }

            // Return the xml string with the object content
            return content;
        }

        public static string RemoveAllWhiteSpaces(this string self)
        {
            return new string(self.Where(c => !char.IsWhiteSpace(c)).ToArray());
        }

        public static string ToLiteral(this string input)
        {
            StringBuilder literal = new StringBuilder(input.Length + 2);
            literal.Append("\"");
            foreach (var c in input)
            {
                switch (c)
                {
                    case '\'': literal.Append(@"\'"); break;
                    case '\"': literal.Append("\\\""); break;
                    case '\\': literal.Append(@"\\"); break;
                    case '\0': literal.Append(@"\0"); break;
                    case '\a': literal.Append(@"\a"); break;
                    case '\b': literal.Append(@"\b"); break;
                    case '\f': literal.Append(@"\f"); break;
                    case '\n': literal.Append(@"\n"); break;
                    case '\r': literal.Append(@"\r"); break;
                    case '\t': literal.Append(@"\t"); break;
                    case '\v': literal.Append(@"\v"); break;
                    default:
                        // ASCII printable character
                        if (c >= 0x20 && c <= 0x7e)
                        {
                            literal.Append(c);
                            // As UTF16 escaped character
                        }
                        else
                        {
                            literal.Append(@"\u");
                            literal.Append(((int)c).ToString("x4"));
                        }
                        break;
                }
            }
            literal.Append("\"");
            return literal.ToString();
        }

        public static string ConvertToSha256(this string randomString)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }

        public static string CleanStr(this string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return "";
            //This function replaces ' with its html code equivalent
            //in order not to terminate the js statement string
            return text.Contains("'") ? text.Replace("'", "&#39;") : text;
            //return HttpContext.Current.Server.HtmlEncode(text);            
        }
    }
}
