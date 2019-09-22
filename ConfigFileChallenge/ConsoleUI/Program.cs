using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Connection strings:");

            var connections = ConfigurationManager.ConnectionStrings;
            if (connections.Count != 0)
            {
                foreach (var connection in connections)
                {
                    Console.WriteLine(connection);
                }
            }


            Console.WriteLine("");


            Console.WriteLine("Application Settings:");

            AddOrUpdateAppSetting("CurrentTime", DateTime.Now.ToLongTimeString());

            var applicationSettings = ConfigurationManager.AppSettings;
            if (applicationSettings.Count != 0)
            {
                foreach (var key in applicationSettings.AllKeys)
                {
                    Console.WriteLine(applicationSettings[key]);
                }
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Adds or updates a setting in App.config appSettings section.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        static public void AddOrUpdateAppSetting(string key, string value)
        {
            // Open App.Config of executable
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            // Add or update an Application Setting.
            config.AppSettings.Settings.Remove(key);
            config.AppSettings.Settings.Add(key, value);
            // Save the configuration file.
            config.Save(ConfigurationSaveMode.Modified);
            // Force a reload of a changed section.
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
