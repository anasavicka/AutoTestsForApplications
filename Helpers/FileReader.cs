using System.Text.Json;

namespace ApiTests.Helpers
{
    public class FileReader
    {
        public static T ReadJson<T>(string fileName)
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", fileName);
            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}