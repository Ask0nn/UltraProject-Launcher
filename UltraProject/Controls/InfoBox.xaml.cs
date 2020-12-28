using MaterialDesignThemes.Wpf;
using PropertyChanged;
using System.Windows;

namespace UltraProject.Controls
{
    /// <summary>
    /// Логика взаимодействия для InfoBox.xaml
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    public partial class InfoBox : Card
    {
        public InfoBox()
        {
            InitializeComponent();
        }

        public string Version
        {
            get { return (string)GetValue(VersionProperty); }
            set { SetValue(VersionProperty, value); }
        }

        public string URL
        {
            get { return (string)GetValue(URLProperty); }
            set { SetValue(URLProperty, value); }
        }

        public static readonly DependencyProperty VersionProperty =
            DependencyProperty.Register("Version", typeof(string), typeof(InfoBox), new PropertyMetadata(default(string)));

        public static readonly DependencyProperty URLProperty =
            DependencyProperty.Register("URL", typeof(string), typeof(InfoBox), new PropertyMetadata(default(string)));
    }
}
