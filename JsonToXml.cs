using System.Text.Json;
using System.Xml;

namespace HomeWork_Seminar_9
{
    public static class JsonToXml
    {
        public static void Convert(JsonDocument jsonDocument, XmlDocument xmlDocument)
        {
            var jsonElement = jsonDocument.RootElement;
            XmlElement rootElement = xmlDocument.CreateElement("Root");
            xmlDocument.AppendChild(rootElement);
            Converter(jsonElement, rootElement);
        }
        private static void Converter(JsonElement jsonElement, XmlElement parentElement)
        {
            if (jsonElement.ValueKind == JsonValueKind.Object)
            {
                foreach (var property in jsonElement.EnumerateObject())
                {

                    XmlElement element = parentElement.OwnerDocument.CreateElement(property.Name);
                    parentElement.AppendChild(element);
                    Converter(property.Value, element);
                }
            }
            else if (jsonElement.ValueKind == JsonValueKind.Array)
            {

                foreach (var arrayElement in jsonElement.EnumerateArray())
                {
                    XmlElement element = parentElement.OwnerDocument.CreateElement("Record");
                    parentElement.AppendChild(element);
                    Converter(arrayElement, element);
                }
            }
            else
            {
                parentElement.InnerText = jsonElement.ToString();
            }
        }
    }
}
