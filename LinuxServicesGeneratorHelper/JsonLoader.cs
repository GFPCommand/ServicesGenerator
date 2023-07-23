using System.Text.Json;

namespace LinuxServicesGeneratorHelper
{
    internal class JsonLoader
    {
        readonly string jsonLoad = string.Empty;

        public JsonLoader()
        {
            jsonLoad = File.ReadAllText("ServiceProperties.json");
        }

        public List<string> ReadServicePropsFromJSON(string prop)
        {
            List<string> result = new List<string>();

            using JsonDocument doc = JsonDocument.Parse(jsonLoad);

            JsonElement elem = doc.RootElement;

            JsonElement e = elem.GetProperty(prop);
            
            for (int i = 0; i< e.GetArrayLength(); i++)
            {
                result.Add(e[i].ToString());
            }

            return result;
        }
    }
}