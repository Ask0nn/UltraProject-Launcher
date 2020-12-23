using Newtonsoft.Json;
using PropertyChanged;
using System.IO;
using UltraProject.Models;

namespace UltraProject.Services
{
    [AddINotifyPropertyChangedInterface]
    public static class LauncherSettingsController
    {
        public static LauncherSettings Settings { get; set; }
        public static string FileSettings { get => "launcher-settings.json"; }

        static LauncherSettingsController()
        {
            if (!File.Exists(FileSettings))
            {
                Settings = new LauncherSettings();
                return;
            }
            var jsonText = File.ReadAllText(FileSettings);
            Settings = JsonConvert.DeserializeObject<LauncherSettings>(jsonText);
        }
    }
}
