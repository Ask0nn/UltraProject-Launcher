using PropertyChanged;
using System.Windows.Controls;
using System.Windows.Input;
using UltraProject.Models;
using UltraProject.Services;

namespace UltraProject.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class AuthorizationViewModel
    {
        #region Свойства
        public SettingsController<ProfileSettings> Settings { get; set; }
        #endregion

        public AuthorizationViewModel()
        {
            Settings = new SettingsController<ProfileSettings>("user-settings.json");
            if (Settings.Settings.UserSettings.IsSave) Auth(Settings.Settings.UserSettings.AuthToken);
        }

        #region Команды
        public ICommand Authorize { get => new DelegateCommand(Auth); }
        #endregion

        #region Методы
        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="obj">PasswordBox</param>
        private void Auth(object obj)
        {
            if (Settings.Settings.UserSettings.IsSave)
                Settings.SaveSettings();
            if (obj is PasswordBox password && !string.IsNullOrEmpty(password.Password))
            {
                System.Windows.MessageBox.Show(password.Password);
            }
        }
        /// <summary>
        /// Авторизация сохраненного пользователя
        /// </summary>
        /// <param name="token">сохраненный токен</param>
        private void Auth(string token)
        {
            if (string.IsNullOrEmpty(token))
                return;
        }
        #endregion
    }
}
