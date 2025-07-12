using System.IO;
using System.Windows;

namespace LeTruongPhucWPF
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            CopyAppSettingsIfNeeded();
        }

        private void CopyAppSettingsIfNeeded()
        {
            const string appSettingsFile = "appsettings.json";
            string currentDirectory = Directory.GetCurrentDirectory();
            string targetPath = Path.Combine(currentDirectory, appSettingsFile);

            if (!File.Exists(targetPath))
            {
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string sourcePath = Path.Combine(baseDirectory, appSettingsFile);

                if (File.Exists(sourcePath))
                {
                    try
                    {
                        File.Copy(sourcePath, targetPath, true);
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show($"Error copying appsettings.json: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
    }
}