using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CurrencyProj.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CurrencyProj.Services
{
    public class BankCurrencyServices : IBankCurrencyServices
    {         
        public List<ComparedCurrency> GetComparedCurrencies(List<CurrencyIsBank> iBCurrency, List<CurrencyLine> yKCurrency)
        {
            List<ComparedCurrency> comparedCurrencies = new List<ComparedCurrency>();
            float number = 2;        
            foreach (var item in iBCurrency)
            {
                if (yKCurrency.Any(z => z.code == item.code))
                {                                
                    ComparedCurrency comparedCurrency = new ComparedCurrency();
                    var currency = yKCurrency.Where(x => x.code == item.code).First();
                    comparedCurrency.Code = currency.code;
                    comparedCurrency.Buy = (item.fxRateBuy + currency.buy) / number;
                    comparedCurrency.Sell = (item.fxRateSell + currency.sell) / number;                                   
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

            WebClient webClient = new WebClient();
            string page = webClient.DownloadString("https://www.yapikredi.com.tr/yatirimci-kosesi/doviz-bilgileri");

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(page);
            var myTable = doc.DocumentNode.SelectSingleNode("//tbody[@id='currencyResultContent']");
            List<List<string>> table = doc.DocumentNode.SelectSingleNode("//tbody[@id='currencyResultContent']")
                        .Descendants("tr")
                        .Where(tr => tr.Elements("td").Count() > 0)
                        .Select(tr => tr.Elements("td").Select(td => td.InnerText.Trim()).ToList())
                        .ToList();

            foreach (var item in table)
            {
                CurrencyLine currency = new CurrencyLine();
                currency.code = item[0];
                currency.buy = (float)Convert.ToDouble(item[2]);
                currency.sell = (float)Convert.ToDouble(item[3]);
                cl.Add(currency);
            }
            return cl;
        }
    }
}
