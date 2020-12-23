using System.Collections.Generic;
using PropertyChanged;

namespace UltraProject.Models
{
    [AddINotifyPropertyChangedInterface]
    public class LauncherSettings
    {
        public string WindowTitle { get; set; }
        public string URL { get; set; }
        public string Version { get; set; }
        public ICollection<Modpack> ModPacks { get; set; }
        public IDictionary<string,string> Connections { get; set; }
    }
}
