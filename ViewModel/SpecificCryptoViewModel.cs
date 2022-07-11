using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using testTask.Data;

namespace testTask.ViewModel
{
    class SpecificCryptoViewModel : DependencyObject
    {
        public ICollectionView Items
        {
            get { return (ICollectionView)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(ICollectionView), typeof(SpecificCryptoViewModel), new PropertyMetadata(null));

        public SpecificCryptoViewModel(string s)
        {
            Items = CollectionViewSource.GetDefaultView(Crypto.GetSpecificCrypto(s));
        }
    }
}
