using System.Collections.Generic;

namespace testTask.Data
{
    public class CryptoList
    {
        public List<Crypto> Data { get; set; }
    }

    public class Crypto
    {
        public string Id { get; set; }
        public string Rank { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string Supply { get; set; }
        public string MaxSupply { get; set; }
        public string MarketCapUsd { get; set; }
        public string VolumeUsd24Hr { get; set; }
        public string PriceUsd { get; set; }
        public string ChangePercent24Hr { get; set; }
        public string Vwap24Hr { get; set; }
        public string Explorer { get; set; }

        public static List<Crypto> GetCryptos(int count = 0)
        {
            List<Crypto> result = new List<Crypto>();

            foreach (Crypto item in ApiData.AssetsGet(count))
            {
                result.Add(new Crypto
                {
                    Id = item.Id,
                    Rank = item.Rank,
                    Symbol = item.Symbol,
                    Name = item.Name,
                    Supply = item.Supply,
                    MaxSupply = item.MaxSupply,
                    MarketCapUsd = item.MarketCapUsd,
                    VolumeUsd24Hr = item.VolumeUsd24Hr,
                    PriceUsd = item.PriceUsd,
                    ChangePercent24Hr = item.ChangePercent24Hr,
                    Vwap24Hr = item.Vwap24Hr,
                    Explorer = item.Explorer
                });
            }

            return result;
        }

        public static List<Crypto> GetSpecificCrypto(string crypto)
        {
            return ApiData.AssetsGetSpecific(crypto);
        }
    }
}
