using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyProj.Models;
namespace CurrencyProj.Services
{
   public  interface IBankCurrencyServices
    {
        List<CurrencyIsBank> GetIBCurrency(string url);
        List<CurrencyLine> GetYKCurrency(string url);
        List<ComparedCurrency> GetComparedCurrencies(List<CurrencyIsBank> iBCurrency, List<CurrencyLine> yKCurrency);
    }
}
