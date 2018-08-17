using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyProj.Models
{

    public class CurrencyIsBank
    {
        public string category { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public float effectiveRateBuy { get; set; }
        public float effectiveRateSell { get; set; }
        public float fxRateBuy { get; set; }
        public float fxRateSell { get; set; }
        public string index { get; set; }
    }

   
}
