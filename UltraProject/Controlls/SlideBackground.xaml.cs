using Newtonsoft.Json;
using PropertyChanged;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using UltraProject.Services;

namespace UltraProject.Controlls
{
    /// <summary>
    /// Логика взаимодействия для SlideBackground.xaml
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    public partial class SlideBackground : UserControl
    {
        #region Свойства
        private DispatcherTimer Timer { get; set; }
        private Random Random { get; set; }
        public ObservableCollection<Models.Image> ImagesCollection { get; set; }
        public Models.Image SelectedImage { get; set; }
        public int SelectedIndex { get; set; }
        #endregion

        public SlideBackground()
        {
            InitializeComponent();
            if (File.Exists("images-path.json"))
            {
                SelectedIndex = 0;
                ImagesCollection = JsonConvert.DeserializeObject<ObservableCollection<Models.Image>>(File.ReadAllText("images-path.json"));
                if (ImagesCollection.Count >= 1)
                {
                    Random = new Random();
                    Timer = new DispatcherTimer { Interval = new TimeSpan(0, 0, 10) };
                    Timer.Tick += (object sender, EventArgs e) => SelectedIndex = Random.Next(0, ImagesCollection.Count - 1);
                    Timer.Start();
                }
            }
        }

        #region Команды
        public ICommand ShowImage { get => new DelegateCommand(OpenImage); }
        #endregion

        #region Методы
        /// <summary>
        /// Открытие картинки в браузере или проводнике
        /// </summary>
        private void OpenImage(object obj)
        {
            var image = SelectedImage;
            if (image.Type.Equals(Models.ImageType.FILE))
                Process.Start("explorer.exe", @"/n, /select, " + image.Path);
            else
                Link.OpenInBrowser(image.Path.ToString());
        }
        #endregion
    }
}
