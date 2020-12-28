using PropertyChanged;

namespace UltraProject.Models
{
    [AddINotifyPropertyChangedInterface]
    public class ProfileSettings
    {
        public UserSettings UserSettings { get; set; }
        public MinecraftSettings MinecraftSettings { get; set; }
    }
}
