using Newtonsoft.Json;
using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Talleres
{
    public static class StringExtend
    {

        public static string PrettyJson(this string unPrettyJson)
        {
            var options = new System.Text.Json.JsonSerializerOptions()
            {
                WriteIndented = true
            };

            var jsonElement = System.Text.Json.JsonSerializer.Deserialize<System.Text.Json.JsonElement>(unPrettyJson.Replace("\r","").Replace("\n",""));

            return System.Text.Json.JsonSerializer.Serialize(jsonElement, options);
        }
        public static void AddPrefix(this XmlDocument doc, string elementsByTagName, string prefix)
        {
            if (doc == null)
                return;

            var x = doc.GetElementsByTagName(elementsByTagName)[0];
            x.Prefix = prefix;
            x.Attributes.RemoveNamedItem("xmlns");
        }

        public static string Beautify(this XmlDocument doc, bool omitXmlDeclaration = true)
        {
            if (doc == null)
                return null;

            StringBuilder sb = new StringBuilder();
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = omitXmlDeclaration
            };
            using XmlWriter writer = XmlWriter.Create(sb, settings);
            doc.Save(writer);

            return sb.ToString();
        }

        public static T DeserializeJson<T>(this string json)
        {
            if (string.IsNullOrEmpty(json))
                return default;

            return JsonConvert.DeserializeObject<T>(json);
        }

        public static string SerializeJson<T>(this T model)
        {
            return JsonConvert.SerializeObject(model, Newtonsoft.Json.Formatting.Indented);
        }

        public static T To<T>(this object obj)
                            where T : class
        {
            if (obj == null)
                return default;

            var json = JsonConvert.SerializeObject(obj);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static bool ToBoolean(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;

            return Convert.ToBoolean(value, CultureInfo.CurrentCulture);
        }

        public static decimal ToDecimal(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return 0;

            return Convert.ToDecimal(value, CultureInfo.CurrentCulture);
        }

        public static Int16 ToInt16(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return 0;

            return Convert.ToInt16(value, CultureInfo.CurrentCulture);
        }

        public static T XmlDeserialize<T>(this string xml)
                                                     where T : class
        {
            if (string.IsNullOrEmpty(xml))
                return default;

            using var reader = new StringReader(xml);
            using var xmlReader = XmlReader.Create(reader);
            var serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(xmlReader);
        }

        public static XmlDocument XmlDocument<T>(this T obj)
                    where T : class
        {
            var xml = obj.XmlSerializer();
            var doc = new XmlDocument();
            doc.LoadXml(xml);
            return doc;
        }

        public static string XmlSerializer<T>(this T obj, bool omitXmlDeclaration = true)
            where T : class
        {
            var serializer = new XmlSerializer(typeof(T));
            var settings = new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = omitXmlDeclaration
            };

            using var stream = new StringWriter();
            using var writer = XmlWriter.Create(stream, settings);
            serializer.Serialize(writer, obj);
            return stream.ToString();
        }
    }
}