using System.Text.Json;
using System.Xml;
using System.Xml.Linq;

namespace HomeWork_Seminar_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            JsonDocument? json = default;
            XmlDocument xml = new XmlDocument();
            try
            {
                json = JsonExtractor.Extract("JsonToParse.json");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            { Console.WriteLine(ex.StackTrace); }
            JsonToXml.Convert(json, xml);
            if (xml.ChildNodes.Count > 0)
            {
                try
                {
                    xml.Save("output.xml");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
                Console.WriteLine("Конвертация завершена успешно, результат записан в файл \"Outpoot.xml\"");
            }
            else
            {
                Console.WriteLine("Произошла ошибка конвертации, изменения не сохранены");
            }

        }
    }
}
