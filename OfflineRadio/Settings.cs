using OfflineRadio.Stations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace OfflineRadio
{
    public class Settings
    {
        public List<Station> SavedStations { get; set; }
        public string StationsFolder { get; set; }
        public string CurrentStation { get; set; }
        public bool LastPlayState { get; set; }

        private static string path;

        public static Settings GetSettingsFromJson()
        {
            path = new FileInfo(Assembly.GetExecutingAssembly().GetName().Name + ".json").FullName;
            if (File.Exists(path) == false)
            {
                File.WriteAllText(path, string.Empty);
            }
            else
            {
                string json = File.ReadAllText(path);
                if (isJson(json))
                {
                    return JsonSerializer.Deserialize<Settings>(File.ReadAllText(path));
                }
            }
            return new Settings();
        }
        public Settings()
        { }

        public void SaveSettings()
        {
            string json = JsonSerializer.Serialize(this);
            File.WriteAllText(path, json);
        }


        private static bool isJson(string source)
        {
            if (source == null)
                return false;

            try
            {
                JsonDocument.Parse(source);
                return true;
            }
            catch (JsonException)
            {
                return false;
            }
        }
    }
}
