using System;
<<<<<<< HEAD
using System.IO;
using System.Windows;
using System.Windows.Resources;
=======
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
>>>>>>> 9e5c18b345624f237cdc4b0e25491377fa4f8a84

namespace UltraProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
<<<<<<< HEAD
            if (!File.Exists("images-path.json"))
            {
                StreamResourceInfo res = GetResourceStream(new Uri("pack://application:,,,/Resources/images-path.json"));
                var file = new FileStream("images-path.json", FileMode.Create, FileAccess.Write);
                res.Stream.CopyTo(file);
                file.Close();
            }
=======
>>>>>>> 9e5c18b345624f237cdc4b0e25491377fa4f8a84
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
        }
    }
}
