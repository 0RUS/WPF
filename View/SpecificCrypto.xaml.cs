using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace testTask.View
{
    public partial class SpecificCrypto : UserControl
    {
        public SpecificCrypto()
        {
            InitializeComponent();
        }
        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Hyperlink link = (Hyperlink)e.OriginalSource;
            System.Diagnostics.Process.Start(link.NavigateUri.ToString());
        }
    }
}
