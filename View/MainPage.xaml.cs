using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using testTask.ViewModel;

namespace testTask.View
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {

            Hyperlink link = (Hyperlink)e.OriginalSource;
            if (link.NavigateUri.ToString().Contains("https"))
            {
                Process.Start(link.NavigateUri.ToString());
                return;
            }
            Application.Current.Windows[0].DataContext = new SpecificCryptoViewModel(link.NavigateUri.ToString());
        }
    }
}