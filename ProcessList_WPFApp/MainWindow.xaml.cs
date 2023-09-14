using System.Diagnostics;
using System.Windows;

namespace ProcessList_WPFApp
{
    //TASK 1
    //Develop an application that can launch a child process and wait for its completion.
    //When the child process is finished, the parent application should display the exit code.
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void LaunchProcess_Click(object sender, RoutedEventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = "calc.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.Start();

            process.WaitForExit();

            int exitCode = process.ExitCode;
            exitCodeLabel.Content = "Exit Code: " + exitCode.ToString();
        }
    }
}
