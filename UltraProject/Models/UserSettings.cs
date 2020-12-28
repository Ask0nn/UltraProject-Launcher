using PropertyChanged;

namespace UltraProject.Models
{
    [AddINotifyPropertyChangedInterface]
    public class UserSettings
    {
        public string Username { get; set; }
        public string AuthToken { get; set; }
        public bool IsSave { get; set; }
    }
}
