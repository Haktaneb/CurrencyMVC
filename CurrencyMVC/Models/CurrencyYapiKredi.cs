using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyProj.Models
{


    public class CurrencyYapiKredi
    {
        public List<CurrencyLine> d { get; set; }
    }

    public class CurrencyLine
    {
        public string code { get; set; }
        public float sell { get; set; }
        public float buy { get; set; }
        public string lastUpdate { get; set; }
        public float Change { get; set; }
        public DateTime Date { get; set; }
        public float PreviousDayBuyingPrice { get; set; }
        public float PreviousDaySellingPrice { get; set; }
        public string DailyStatus { get; set; }
    }




}
