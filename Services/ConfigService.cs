using Newtonsoft.Json;
using System.IO;
using System.Xml;

namespace Tp_Final_Fred.Services
{
    public class AppConfig
    {
        public string Language { get; set; } = "fr";
        public string ApiKey { get; set; } = "";
    }

    public static class ConfigService
    {
        private static readonly string _path = "config.json";

        public static AppConfig Load()
        {
            if (!File.Exists(_path))
            {
                var defaultConfig = new AppConfig();
                Save(defaultConfig);
                return defaultConfig;
            }

            var json = File.ReadAllText(_path);
            return JsonConvert.DeserializeObject<AppConfig>(json);
        }

        public static void Save(AppConfig config)
        {
            var json = JsonConvert.SerializeObject(config, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(_path, json);
        }
    }
}
