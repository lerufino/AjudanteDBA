using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml;

namespace AjudanteDBA.Utilities
{
    public class Config
    {
        public string Database { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string PathToBackup { get; set; }

        public void ConfigureEnvironment()
        {
            string configFilePath = "config.env";

            Config config;

            if (File.Exists(configFilePath))
            {
                string json = File.ReadAllText(configFilePath);
                config = JsonSerializer.Deserialize<Config>(json);
            }
            else
            {
                config = new Config();
                string defaultJson = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(configFilePath, defaultJson);
            }
        }
    }

}


