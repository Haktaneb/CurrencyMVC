using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyProj.Models
{
    public class ComparedCurrency
    {
        public string Code { get; set; }
        public float Sell { get; set; }
        public float Buy { get; set; }
    }
}
