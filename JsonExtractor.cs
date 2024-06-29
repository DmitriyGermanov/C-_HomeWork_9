using System.Text.Json;

namespace HomeWork_Seminar_9
{
    public static class JsonExtractor
    {
    
        public static JsonDocument Extract(string fileName)
        {
            string json;
            var currentDirectory = new DirectoryInfo(Environment.CurrentDirectory);
            var pathToFile = Path.Combine(currentDirectory.FullName, fileName);
            if (!Path.Exists(pathToFile))
                throw new FileNotFoundException("Файл с таким именем не был найден!");
            else
            {
                json = File.ReadAllText(pathToFile);
            }
            return JsonDocument.Parse(json);
        }
    }
}
