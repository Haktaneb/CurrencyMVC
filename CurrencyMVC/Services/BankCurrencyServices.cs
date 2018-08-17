using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CurrencyProj.Models;
using Newtonsoft.Json;

namespace CurrencyProj.Services
{
    public class BankCurrencyServices : IBankCurrencyServices
    {
        
     
        public List<ComparedCurrency> GetComparedCurrencies(List<CurrencyIsBank> iBCurrency, List<CurrencyLine> yKCurrency)
        {
            List<ComparedCurrency> comparedCurrencies = new List<ComparedCurrency>();
            float number = 2;
         
           
            foreach (var item in yKCurrency)
            {
                if (iBCurrency.Any(z => z.code == item.code))
                {
                   
                    
                    ComparedCurrency comparedCurrency = new ComparedCurrency();
                    var currency = iBCurrency.Where(x => x.code == item.code).First();
                    comparedCurrency.Code = currency.code;
                    comparedCurrency.Buy = (currency.fxRateBuy + item.buy) / number;
                    comparedCurrency.Sell = (currency.fxRateSell + item.sell) / number;
                    
                 
                    comparedCurrencies.Add(comparedCurrency);
                    
                }        
            }
            return comparedCurrencies;
        }

        public List<CurrencyIsBank> GetIBCurrency(string url)
        {  
            var datetime = DateTime.Now.ToString("yyyy/M/dd");
            datetime = datetime.Replace(".", "-");
            url = url + datetime;

            string currencyIsbank = new System.Net.WebClient().DownloadString(url);
            var list = JsonConvert.DeserializeObject<List<CurrencyIsBank>>(currencyIsbank);
            return list;
        }

        public List<CurrencyLine> GetYKCurrency(string url)
        {
            List<CurrencyLine> cl = new List<CurrencyLine>();
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    CurrencyYapiKredi response = JsonConvert.DeserializeObject<CurrencyYapiKredi>(result);
                    var x = response.d.ToList();
                    cl = x;
                }
            }
            return cl;

        }
    }
}
