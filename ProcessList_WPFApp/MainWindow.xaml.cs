using System.Diagnostics;
using System;
using System.Windows;

namespace ProcessList_WPFApp
{
    //TASK 4
    //Develop a WPF application that allows the user to launch other programs.
    //The user can start:
    //Notepad.
    //Calculator.
    //Paint.
    //Their own, another application
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LaunchNotepad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start("notepad.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error launching Notepad: " + ex.Message);
            }
        }

        private void LaunchCalculator_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start("calc.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error launching Calculator: " + ex.Message);
            }
        }

        private void LaunchPaint_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start("mspaint.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error launching Paint: " + ex.Message);
            }
        }

        private void LaunchSpotify_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start("C:\\Users\\User\\AppData\\Roaming\\Spotify\\Spotify.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error launching custom program: " + ex.Message);
            }
        }
    }
}
