using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CurrencyProj.Models;
using CurrencyProj.Services;
using CurrencyMVC.Models;
namespace CurrencyMVC.Controllers
{
    public class CurrencyController : Controller
    {
        private readonly IBankCurrencyServices bankCurrencyServices;
        private readonly IEmailNotifier emailNotifier;

        public CurrencyController(IBankCurrencyServices bankCurrencyServices, IEmailNotifier emailNotifier)
        {
            this.bankCurrencyServices = bankCurrencyServices;
            this.emailNotifier = emailNotifier;
        }
        public IActionResult Index()
        {
           
            string iBankurl = @"https://www.isbank.com.tr/_layouts/ISB_DA/HttpHandlers/FxRatesHandler.ashx?Lang=tr&fxRateType=INTERACTIVE&date=";
            string yKBankUrl = @"https://www.yapikredi.com.tr/_ajaxproxy/general.aspx/LoadMainCurrencies";
            var iBankCur = bankCurrencyServices.GetIBCurrency(iBankurl);
            var yKBankCur = bankCurrencyServices.GetYKCurrency(yKBankUrl);
            var comparedCur = bankCurrencyServices.GetComparedCurrencies(iBankCur, yKBankCur);
            CurrencyViewModel currencyViewModel = new CurrencyViewModel() { ComparedCurrencies = comparedCur,CurrencyIsBanks = iBankCur ,CurrencyYapiKredis = yKBankCur};
            return View(currencyViewModel);
        }
    }
}