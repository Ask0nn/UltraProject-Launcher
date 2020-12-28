using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Resources;

namespace UltraProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            if (!File.Exists("user-settings.json"))
            {
                StreamResourceInfo res = GetResourceStream(new Uri("pack://application:,,,/Resources/user-settings.json"));
                var file = new FileStream("user-settings.json", FileMode.Create, FileAccess.Write);
                res.Stream.CopyTo(file);
                file.Close();
            }

            if (!File.Exists("images-path.json"))
            {
                StreamResourceInfo res = GetResourceStream(new Uri("pack://application:,,,/Resources/images-path.json"));
                var file = new FileStream("images-path.json", FileMode.Create, FileAccess.Write);
                res.Stream.CopyTo(file);
                file.Close();
            }

            if (!File.Exists("launcher-settings.json"))
            {
                StreamResourceInfo res = GetResourceStream(new Uri("pack://application:,,,/Resources/launcher-settings.json"));
                var file = new FileStream("launcher-settings.json", FileMode.Create, FileAccess.Write);
                res.Stream.CopyTo(file);
                file.Close();
            }

            var files = GetResources("resources/background/*");
            if (files.Count >= 1)
            {
                if (!Directory.Exists("Background"))
                    Directory.CreateDirectory("Background");

                foreach (var file in files)
                {
                    var path = file.Key.Replace(@"resources/", "");
                    if (!File.Exists(path))
                    {
                        var newFile = new FileStream(path, FileMode.Create, FileAccess.Write);
                        file.Value.CopyTo(newFile);
                        newFile.Close();
                    }
                }
            }
        }
        /// <summary>
        /// Получение ресурсов по фильтру
        /// </summary>
        /// <param name="filter">Фильтр</param>
        private static IDictionary<string, UnmanagedMemoryStream> GetResources(string filter)
        {
            var asm = Assembly.GetEntryAssembly();
            string resName = asm.GetName().Name + ".g.resources";
            Stream stream = asm.GetManifestResourceStream(resName);
            ResourceReader reader = new ResourceReader(stream);
            IDictionary<string, UnmanagedMemoryStream> ret = new Dictionary<string, UnmanagedMemoryStream>();
            foreach (DictionaryEntry res in reader)
            {
                string path = (string)res.Key;
                if (Regex.IsMatch(path, filter))
                    ret.Add(path, (UnmanagedMemoryStream)res.Value);
            }
            return ret;
        }
        private void Application_Exit(object sender, ExitEventArgs e)
        {
        }
    }
}
