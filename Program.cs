using System;

namespace Application_development_in_C_
{
    class Program
    {
        static void Main(string[] args)
        {
            string json = @"{
                ""name"": ""Ivan Petrov"",
                ""age"": 25,
                ""city"": ""Moscow""
            }";

            IJsonToXmlConverter converter = new JsonToXmlConverter();
            string xml = converter.ConvertJsonToXml(json);
            Console.WriteLine(xml);
        }
    }
}