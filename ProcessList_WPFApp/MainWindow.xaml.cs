using System.Diagnostics;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;

namespace ProcessList_WPFApp
{
    //Develop an application that can launch a child process.
    //Depending on the user's choice, 
    //the parent application should either wait for the child process to finish and display the exit code, 
    //or forcefully terminate the child process
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

            if (waitRadioButton.IsChecked == true)
            {
                process.WaitForExit();
            }
            else if (terminateRadioButton.IsChecked == true)
            {
                process.Kill();
            }

            int exitCode = process.ExitCode;
            exitCodeLabel.Content = "Exit Code: " + exitCode.ToString();
        }
    }
}
