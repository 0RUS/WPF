using System.Windows;
using testTask.ViewModel;

namespace testTask
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainPage_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new MainPageViewModel();
        }

        private void AllCryptos_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new AllCryptosViewModel();
        }
        private void Converter_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new ConverterViewModel();
        }
    }
}