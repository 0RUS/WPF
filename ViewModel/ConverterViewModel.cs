using System;
using System.Collections.Generic;
using System.Windows;
using testTask.Data;

namespace testTask.ViewModel
{
    class ConverterViewModel : DependencyObject
    {
        private static bool flag = true;
        public List<Crypto> Cryptos { get; set; }

        public Crypto FirstCrypto
        {
            get { return (Crypto)GetValue(firstCryptoProperty); }
            set { SetValue(firstCryptoProperty, value); }
        }

        public static readonly DependencyProperty firstCryptoProperty =
            DependencyProperty.Register("firstCrypto", typeof(Crypto), typeof(ConverterViewModel), new PropertyMetadata(null, SecondConvert));

        public Crypto SecondCrypto
        {
            get { return (Crypto)GetValue(secondCryptoProperty); }
            set { SetValue(secondCryptoProperty, value); }
        }

        public static readonly DependencyProperty secondCryptoProperty =
            DependencyProperty.Register("secondCrypto", typeof(Crypto), typeof(ConverterViewModel), new PropertyMetadata(null, FirstConvert));

        public string FirstValue
        {
            get { return (string)GetValue(firstValueProperty); }
            set { SetValue(firstValueProperty, value); }
        }

        public static readonly DependencyProperty firstValueProperty =
            DependencyProperty.Register("FirstValue", typeof(string), typeof(ConverterViewModel), new PropertyMetadata("", FirstConvert));

        public string SecondValue
        {
            get { return (string)GetValue(secondValueProperty); }
            set { SetValue(secondValueProperty, value); }
        }

        public static readonly DependencyProperty secondValueProperty =
            DependencyProperty.Register("SecondValue", typeof(string), typeof(ConverterViewModel), new PropertyMetadata("", SecondConvert));

        private static void FirstConvert(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (flag)
            {
                flag = false;
                if (d is ConverterViewModel current)
                {
                    if (current.FirstValue == "") { flag = true; return; }
                    if (current.FirstValue == "0")
                    {
                        current.SecondValue = "0";
                        flag = true;
                        return;
                    }
                    if (current.FirstCrypto == null || current.SecondCrypto == null) { flag = true; return; }

                    double fc = Convert.ToDouble(current.FirstCrypto.PriceUsd.Replace(".", ","));
                    double sc = Convert.ToDouble(current.SecondCrypto.PriceUsd.Replace(".", ","));
                    double fv = Convert.ToDouble(current.FirstValue);
                    current.SecondValue = (fv * sc / fc).ToString("0.0000");
                }
                flag = true;
            }
        }
        private static void SecondConvert(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (flag)
            {
                flag = false;
                if (d is ConverterViewModel current)
                {
                    if (current.SecondValue == "") { flag = true; return; }
                    if (current.SecondValue == "0")
                    {
                        current.SecondValue = "0";
                        flag = true;
                        return;
                    }
                    if (current.FirstCrypto == null || current.SecondCrypto == null) { flag = true; return; }

                    double fc = Convert.ToDouble(current.FirstCrypto.PriceUsd.Replace(".", ","));
                    double sc = Convert.ToDouble(current.SecondCrypto.PriceUsd.Replace(".", ","));
                    double sv = Convert.ToDouble(current.SecondValue);
                    current.FirstValue = (sv * sc / fc).ToString("0.0000");
                }
                flag = true;
            }
        }

        private static List<Crypto> ConverterGet()
        {
            var tmp = new List<Crypto>();
            foreach (Crypto item in ApiData.AssetsGet())
            {
                tmp.Add(new Crypto
                {
                    Symbol = item.Symbol,
                    PriceUsd = item.PriceUsd
                });
            }
            return tmp;
        }

        public ConverterViewModel()
        {
            Cryptos = ConverterGet();
        }
    }
}
