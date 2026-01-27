using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OfflineRadio.Stations;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace OfflineRadio
{
    public class Settings
    {
        public List<Station> SavedStations { get; set; }
        public string StationsFolder { get; set; }
        public string CurrentStation { get; set; }
        public bool LastPlayState { get; set; }
        public int LastVolume { get; set; } = -1;
        public bool LastOnTop { get; set; }

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
                    return JsonConvert.DeserializeObject<Settings>(File.ReadAllText(path));
                }
            }
            return new Settings();
        }
        public Settings()
        { }

        public void SaveSettings()
        {
            string json = JsonConvert.SerializeObject(this);
            File.WriteAllText(path, json);
        }


        private static bool isJson(string source)
        {
            if (source == null)
                return false;

            try
            {
                JObject.Parse(source);
                return true;
            }
            catch (JsonException)
            {
                return false;
            }
        }
    }
}
