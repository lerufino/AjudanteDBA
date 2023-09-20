using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml;

namespace AjudanteDBA.Utilities
{
   
    public class ConfigEnv
    {
        public string Datasource { get; set; }
        public string Database { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string PathToBackup { get; set; }

        public ConfigEnv()
        {
            
        }

        public void LoadConfiguration()
        {
            string configFilePath = "config.env";

            try
            {
                if (File.Exists(configFilePath))
                {
                    string json = File.ReadAllText(configFilePath);
                    ConfigEnv config = JsonSerializer.Deserialize<ConfigEnv>(json);

                    Datasource = config.Datasource;
                    Database = config.Database;
                    User = config.User;
                    Password = config.Password;
                    PathToBackup = config.PathToBackup;
                }
                else
                {
                    Datasource = "";
                    Database = "";
                    User = "";
                    Password = "";
                    PathToBackup = "";

                    string defaultJson = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(configFilePath, defaultJson);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar configurações do arquivo." + ex.Message);
                throw;
            }
        }

        public override string ToString()
        {
            return $"Datasource: {Datasource},Database: {Database}, User: {User}, Caminho do Backup: {PathToBackup}.";
        }
    }

}


