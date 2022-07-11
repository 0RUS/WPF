using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace testTask.Data
{
    class ApiData
    {
        public static List<Crypto> AssetsGet(int limit = 0)
        {
            string request = limit == 0 ? "https://api.coincap.io/v2/assets" : $"https://api.coincap.io/v2/assets?limit={limit}";
            return GetResponse(request);
        }

        public static List<Crypto> AssetsGetSpecific(string specific)
        {
            return GetResponse($"https://api.coincap.io/v2/assets?ids={specific}");
        }

        private static List<Crypto> GetResponse(string path)
        {
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(path));

            WebReq.Method = "GET";

            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

            Console.WriteLine(WebResp.StatusCode);
            Console.WriteLine(WebResp.Server);

            string jsonString;
            using (Stream stream = WebResp.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

            CryptoList data = JsonConvert.DeserializeObject<CryptoList>(jsonString);

            return data.Data;
        }

    }
}
