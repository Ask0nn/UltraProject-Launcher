using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Input;

namespace UltraProject.Services
{
    public static class Link
    {
        public static ICommand OpenLink 
        {
            get
            {
                return new DelegateCommand((obj) => 
                {
                    if (!string.IsNullOrEmpty((string)obj))
                        OpenInBrowser((string)obj);
                });
            }
        }

        public static void OpenInBrowser(string url)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                url = url.Replace("&", "^&");
                Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true, UseShellExecute = false });
            }
        }
    }
}
