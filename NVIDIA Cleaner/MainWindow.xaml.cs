using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace NVIDIA_Cleaner
{
    public partial class MainWindow : Window
    {

        private TextBox logLabel;

        public MainWindow()
        {
            InitializeComponent();

            logLabel = (TextBox) FindName("LogLabel");

            Button cleanButton = (Button) FindName("CleanButton");
            cleanButton.Click += cleanButtonClick;
        }

        private async void cleanButtonClick(object sender, RoutedEventArgs e)
        {
            await log("Starting...");

            string[] paths = { Paths.NVCache, Paths.DCache, Paths.GlCache, Paths.Temp };

            foreach (string path in paths)
            {
                await clearFolder(path);
            }

            await log("Done");
        }

        private async Task log(string text)
        {
            logLabel.Text = logLabel.Text + "\n" + text;
            logLabel.ScrollToEnd();
        }

        private async Task clearFolder(string path)
        {
            if (Directory.Exists(path))
            {
                await log("Clearing at: " + path);

                DirectoryInfo di = new DirectoryInfo(path);

                foreach (FileInfo file in di.GetFiles())
                {
                    try
                    {
                        file.Delete();
                    }
                    catch 
                    {
                        await log("Delete failed at path: " + file.FullName);
                    }
                }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    try
                    {
                        dir.Delete(true);
                    }
                    catch
                    {
                        await log("Delete failed at path: " + dir.FullName);
                    }
                }
            }
            else
            {
                await log("Folder does not exist: " + path);
            }
        }
    }
}
