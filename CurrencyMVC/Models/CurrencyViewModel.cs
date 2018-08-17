using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyProj.Models;
namespace CurrencyMVC.Models
{
    public class CurrencyViewModel
    {
        public List<ComparedCurrency> ComparedCurrencies { get; set; }
        public List<CurrencyIsBank>  CurrencyIsBanks{ get; set; }
        public List<CurrencyLine> CurrencyYapiKredis { get; set; }
    }
}
