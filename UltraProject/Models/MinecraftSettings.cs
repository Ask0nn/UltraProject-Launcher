using PropertyChanged;

namespace UltraProject.Models
{
    [AddINotifyPropertyChangedInterface]
    public class MinecraftSettings
    {
        public int Memory { get; set; }
        public string GameDir { get; set; }
        public string JavaType { get; set; }
        public string Javax64 { get; private set; }
        public string Javax32 { get; private set; }
        public bool JavaBuiltIn { get; set; }
        public string JavaPath { get; set; }
        public bool Debug { get; set; }
    }
}
