using System.Text.Json;
using System.Xml;

namespace Application_development_in_C_
{
    public class JsonToXmlConverter : IJsonToXmlConverter
    {
        public string ConvertJsonToXml(string json)
        {
            using (JsonDocument doc = JsonDocument.Parse(json))
            {
                XmlDocument xmlDoc = new XmlDocument();
                XmlElement rootElement = xmlDoc.CreateElement("root");
                xmlDoc.AppendChild(rootElement);
                ConvertJsonToXmlRecursive(doc.RootElement, xmlDoc, rootElement);
                return xmlDoc.InnerXml;
            }
        }

        private void ConvertJsonToXmlRecursive(JsonElement element, XmlDocument xmlDoc, XmlNode xmlNode)
        {
            switch (element.ValueKind)
            {
                case JsonValueKind.Object:
                    foreach (JsonProperty prop in element.EnumerateObject())
                    {
                        XmlElement newNode = xmlDoc.CreateElement(prop.Name);
                        xmlNode.AppendChild(newNode);
                        ConvertJsonToXmlRecursive(prop.Value, xmlDoc, newNode);
                    }
                    break;
                case JsonValueKind.Array:
                    foreach (JsonElement child in element.EnumerateArray())
                    {
                        XmlElement newNode = xmlDoc.CreateElement("item");
                        xmlNode.AppendChild(newNode);
                        ConvertJsonToXmlRecursive(child, xmlDoc, newNode);
                    }
                    break;
                default:
                    xmlNode.InnerText = element.ToString();
                    break;
            }
        }
    }
}