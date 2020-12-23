using PropertyChanged;

namespace UltraProject.Models
{
    [AddINotifyPropertyChangedInterface]
    public class Modpack
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string IconKind { get; set; }
        public string StartString { get; set; }
        public string Path { get; set; }
        public bool IsInstall { get; set; }
    }
}
