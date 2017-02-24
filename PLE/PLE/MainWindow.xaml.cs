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
        private int threads = 0;
        private Importer i;
        private listConverter conv;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void buttonImport_Click(object sender, RoutedEventArgs e)
        {
            if (sender.Equals(buttonImport))
            {
                i = new Importer(textBoxImport.Text,threads);
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

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Console.WriteLine(slider.Value);
            threads = (int)slider.Value;
        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            i.clearTable();
        }
    }
}
