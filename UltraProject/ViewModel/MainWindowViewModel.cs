using PropertyChanged;
using UltraProject.Models;
using UltraProject.Services;

namespace UltraProject.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class MainWindowViewModel
    {
        #region Свойства
        public SettingsController<LauncherSettings> Settings { get; set; }
        #endregion

        public MainWindowViewModel()
        {
            Settings = new SettingsController<LauncherSettings>("launcher-settings.json");
        }
    }
}
