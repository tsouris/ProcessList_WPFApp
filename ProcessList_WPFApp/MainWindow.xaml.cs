using System;
using System.Diagnostics;
using System.Windows;

namespace ProcessList_WPFApp
{
    //TASK 4
    //Develop an application that can launch a child process and pass command-line arguments to it.
    //The arguments should be the path to a file and a word to search for. 
    //For example, the arguments:
    //E:\someFolder
    //bicycle
    //The child process should display the number of times the word 'bicycle' is encountered in the file.

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string filePath = FilePathTextBox.Text;
                string searchWord = SearchWordTextBox.Text;

                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = @"C:\\Users\\User\\source\\repos\\ChildProcess\\ChildProcess\\bin\\Debug\\net7.0\\ChildProcess.exe"; // Assuming the child process is a separate executable
                startInfo.Arguments = $"{filePath} {searchWord}";
                startInfo.RedirectStandardOutput = true;
                startInfo.UseShellExecute = false;
                startInfo.CreateNoWindow = true;

                using (Process process = new Process())
                {
                    process.StartInfo = startInfo;
                    process.Start();

                    string result = process.StandardOutput.ReadToEnd();
                    ResultLabel.Content = $"Result: {result}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            
        }
    }
}
