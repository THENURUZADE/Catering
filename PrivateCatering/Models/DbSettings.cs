using Newtonsoft.Json;
using PrivateCatering.Core.Security;
using PrivateCatering.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateCatering.Models
{
    public class DbSettings
    { 
        private DbSettings()
        {

        }
        public string DbSource { get; set; }
        public string DbName { get; set; }
        public bool IntegratedSecurity { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public const string CONFIGFOLDER = @"Config";
        public const string DBSETTINGS = @"Config\DbSettings.json";
        private static DbSettings settings = new DbSettings();

        public static DbSettings Get()
        {
            Directory.CreateDirectory(CONFIGFOLDER);

            if (File.Exists(DBSETTINGS))
            {
                string json = File.ReadAllText(DBSETTINGS);
                settings = JsonConvert.DeserializeObject<DbSettings>(json);
                if (settings.Password != null)
                    settings.Password = MySecurityHelper.Decrypt(settings.Password);
            }
            else
            {
                Helper.Log(new Exception("Config file not found    \n"));

                settings = new DbSettings()
                {
                    DbSource = "",
                    DbName = "Catering(example)",
                    IntegratedSecurity = true
                };

                string json = JsonConvert.SerializeObject(settings);
                File.WriteAllText(DBSETTINGS, json);
            }

            return settings;
        }

        public void SaveConfig()
        {
            if (Password != null)
                Password = MySecurityHelper.Encrypt(Password);
            string json = JsonConvert.SerializeObject(this);
            File.WriteAllText(DBSETTINGS, json);
        }

        public string GetConnectionString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = settings.DbSource;
            builder.InitialCatalog = settings.DbName;
            builder.IntegratedSecurity = settings.IntegratedSecurity;
            if (!settings.IntegratedSecurity)
            {
                builder.UserID = settings.Username ?? string.Empty;
                builder.Password = settings.Password ?? string.Empty;
            }
            return builder.ConnectionString;
        }
    }
}
