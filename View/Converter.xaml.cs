using System.Windows.Controls;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace testTask.View
{
    public partial class Converter : UserControl
    {
        public Converter()
        {
            InitializeComponent();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}