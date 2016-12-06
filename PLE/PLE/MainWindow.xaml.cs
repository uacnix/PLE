using Microsoft.Win32;
using System;
using System.Windows;

namespace PLE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void buttonImport_Click(object sender, RoutedEventArgs e)
        {
            if (sender.Equals(buttonImport))
            {
                Importer i = new Importer(textBoxImport.Text,8);
                i.Import();
            }
        }

        private void buttonBrowseImport_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Environment.GetEnvironmentVariable("USERPROFILE") + "\\Desktop";
            if (ofd.ShowDialog() == true)
            {
                textBoxImport.Text = ofd.FileName;
            }
            
        }
    }
}
