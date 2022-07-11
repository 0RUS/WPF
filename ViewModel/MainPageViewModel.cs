﻿using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using testTask.Data;

namespace testTask.ViewModel
{
    class MainPageViewModel : DependencyObject
    {
        public string CryptoFilter
        {
            get { return (string)GetValue(CryptoFilterProperty); }
            set { SetValue(CryptoFilterProperty, value); }
        }

        public static readonly DependencyProperty CryptoFilterProperty =
            DependencyProperty.Register("CryptoFilter", typeof(string), typeof(MainPageViewModel), new PropertyMetadata("", CryptoFilter_Changed));

        private static void CryptoFilter_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is MainPageViewModel current)
            {
                current.Items.Filter = null;
                current.Items.Filter = current.FilterCrypto;
            }
        }

        public ICollectionView Items
        {
            get { return (ICollectionView)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(ICollectionView), typeof(MainPageViewModel), new PropertyMetadata(null));

        public MainPageViewModel()
        {
            Items = CollectionViewSource.GetDefaultView(Crypto.GetCryptos(10));
            Items.Filter = FilterCrypto;
        }

        private bool FilterCrypto(object obj)
        {
            bool result = true;
            if (!string.IsNullOrWhiteSpace(CryptoFilter) && obj is Crypto current && !current.Name.Contains(CryptoFilter) && !current.Symbol.Contains(CryptoFilter))
            {
                result = false;
            }
            return result;
        }
    }
}
