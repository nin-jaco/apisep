using System;
using System.IO;
using System.Xml.Serialization;

namespace ApiSep.Library.Utilities
{
    public static class XmlUtility
    {
        public static string UnescapeXmlValue(string xmlString)
        {
            return string.IsNullOrWhiteSpace(xmlString)
                ? xmlString
                : xmlString.Replace("&apos;", "'").Replace("&quot;", "\"").Replace("&gt;", ">").Replace("&lt;", "<")
                    .Replace("&amp;", "and").Replace("&", " and ");
        }

        public static string EscapeXmlValue(string xmlString)
        {
            return string.IsNullOrWhiteSpace(xmlString)
                ? xmlString
                : xmlString.Replace("&", "&amp;").Replace("'", "&apos;").Replace("\"", "&quot;").Replace(">", "&gt;")
                    .Replace("<", "&lt;");
        }


        public static string SerializeObject<T>(T dataObject)
        {
            if (dataObject == null)
            {
                return string.Empty;
            }
            try
            {
                using (StringWriter stringWriter = new System.IO.StringWriter())
                {
                    var serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(stringWriter, dataObject);
                    return stringWriter.ToString();
                }
            }
            catch (Exception ex)
            {
                //LogHelper.Error(dataObject.GetType(), "Failed to serialize object", ex);
                return string.Empty;
            }
        }

        public static T DeserializeObject<T>(string xml)
            where T : new()
        {
            if (string.IsNullOrEmpty(xml))
            {
                return new T();
            }
            try
            {
                using (var stringReader = new StringReader(xml))
                {
                    var serializer = new XmlSerializer(typeof(T));
                    return (T)serializer.Deserialize(stringReader);
                }
            }
            catch (Exception ex)
            {
                //LogHelper.Error(typeof(T), "Failed to serialize xml to object: " + xml, ex);
                return new T();
            }
        }



    }
}
