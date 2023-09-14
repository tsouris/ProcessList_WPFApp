using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Threading;

namespace ProcessList_WPFApp
{
    //TASK 1
    //Develop an application that displays a list of processes.
    //User can specify a time interval to update the list.
    //Necessarily create a windowed application interface.

    //TASK 2
    //Add to the first task the possibility of choosing a specific one process in the list.
    //When selecting a process, detailed information about him 
    //Example:
    // Process ID.
    // Start time.
    // The total amount of CPU time spent on this process.
    // Number of streams.
    // The number of copies of a process of this type (if you have a running five notebooks, five should appear)

    //TASK 3
    //Add the ability to terminate the selected process to the second task.

    public partial class MainWindow : Window
    {
        List<Process> processes;
        DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();

            processes = new List<Process>(Process.GetProcesses());

            for (int i = 0; i < processes.Count; i++)
            {
                processListBox.Items.Add($"{i + 1}. {processes[i].ProcessName}");
            }

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(10); // Change the interval as needed (e.g., 10 seconds).
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshProcessList();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            RefreshProcessList();
        }

        private void RefreshProcessList()
        {
            processListBox.Items.Clear();
            processes.Clear();

            processes.AddRange(Process.GetProcesses());

            for (int i = 0; i < processes.Count; i++)
            {
                processListBox.Items.Add($"{i + 1}. {processes[i].ProcessName}");
            }
        }

        private void ViewDetails_Click(object sender, RoutedEventArgs e)
        {
            int selection = int.Parse(selectionTextBox.Text);

            if (selection > 0 && selection <= processes.Count)
            {
                Process selectedProcess = processes[selection - 1];
                detailsTextBox.Text = $"Process Name: {selectedProcess.ProcessName}\n" +
                                      $"Process ID: {selectedProcess.Id}\n" +
                                      $"Start Time: {selectedProcess.StartTime}\n" +
                                      $"Total CPU Time: {selectedProcess.TotalProcessorTime}\n" +
                                      $"Number of Threads: {selectedProcess.Threads.Count}\n";
            }
            else
            {
                detailsTextBox.Text = "Invalid selection.";
            }
        }

        private void EndProcess_Click(object sender, RoutedEventArgs e)
        {
            int selection;
            if (int.TryParse(selectionTextBox.Text, out selection) && selection > 0 && selection <= processes.Count)
            {
                Process selectedProcess = processes[selection - 1];
                try
                {
                    selectedProcess.Kill();
                    detailsTextBox.Text = $"Process {selectedProcess.ProcessName} terminated successfully.";
                }
                catch (Exception ex)
                {
                    detailsTextBox.Text = $"Error terminating process: {ex.Message}";
                }
            }
            else
            {
                detailsTextBox.Text = "Invalid selection.";
            }
        }
    }
}
