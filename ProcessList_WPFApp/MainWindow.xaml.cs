using System.Diagnostics;
using System.Windows;

namespace ProcessList_WPFApp
{
    //Develop an application that can launch a child process and pass command-line arguments to it.
    //The arguments should consist of two numbers and the operation to be performed. 
    //For example, the arguments: 
    //7
    //3
    //+
    //The child process should display the arguments and output the result of adding '10' to the screen.

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LaunchProcess_Click(object sender, RoutedEventArgs e)
        {
            double number1, number2;
            if (double.TryParse(number1TextBox.Text, out number1) && double.TryParse(number2TextBox.Text, out number2))
            {
                string arguments = $"{number1} {number2}";

                Process process = new Process();
                process.StartInfo.FileName = @"C:\Users\User\source\repos\ChildProcess\ChildProcess\bin\Debug\net7.0\ChildProcess.exe";
                process.StartInfo.Arguments = arguments;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.Start();

                process.WaitForExit();

                string result = process.StandardOutput.ReadToEnd();
                resultTextBlock.Text = "Result: " + result;
            }
            else
            {
                MessageBox.Show("Please enter valid numbers.");
            }
        }
    }
}
