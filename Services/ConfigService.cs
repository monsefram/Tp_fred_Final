using System.IO;
using System.Text.Json;

namespace Tp_Final_Fred.Services
{
    public class AppConfig
    {
        public string Language { get; set; } = "fr";
        public string ApiKey { get; set; } = "";
    }

    public static class ConfigService
    {
        private static readonly string FilePath =
            Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                "Tp_Final_Fred.config.json"
            );

        public static AppConfig Load()
        {
            if (!File.Exists(FilePath))
                return new AppConfig();

            var json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<AppConfig>(json)!;
        }

        public static void Save(AppConfig config)
        {
            var json = JsonSerializer.Serialize(config, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(FilePath, json);
        }
    }
}
