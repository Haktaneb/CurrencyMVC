using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CurrencyProj.Models;
using CurrencyProj.Services;
using CurrencyMVC.Models;
using System.Net;
using HtmlAgilityPack;

namespace CurrencyMVC.Controllers
{
    public class CurrencyController : Controller
    {
        private readonly IBankCurrencyServices bankCurrencyServices;
        private readonly string iBankurl = @"https://www.isbank.com.tr/_layouts/ISB_DA/HttpHandlers/FxRatesHandler.ashx?Lang=tr&fxRateType=INTERACTIVE&date=";
        private readonly string yKBankUrl = @"https://www.yapikredi.com.tr/_ajaxproxy/general.aspx/LoadMainCurrencies";

        public CurrencyController(IBankCurrencyServices bankCurrencyServices)
        {
            this.bankCurrencyServices = bankCurrencyServices;
        }
        public IActionResult Index()
        {       
            var iBankCur = bankCurrencyServices.GetIBCurrency(iBankurl);
            var yKBankCur = bankCurrencyServices.GetYKCurrency(yKBankUrl);
            var comparedCur = bankCurrencyServices.GetComparedCurrencies(iBankCur, yKBankCur);
            CurrencyViewModel currencyViewModel = new CurrencyViewModel() { ComparedCurrencies = comparedCur, CurrencyIsBanks = iBankCur, CurrencyYapiKredis = yKBankCur };
            return View(currencyViewModel);
        }
        [HttpPost]
        public IActionResult CurrencyInformation()
        {
            var iBankCur = bankCurrencyServices.GetIBCurrency(iBankurl);
            var yKBankCur = bankCurrencyServices.GetYKCurrency(yKBankUrl);
            var comparedCur = bankCurrencyServices.GetComparedCurrencies(iBankCur, yKBankCur);
            CurrencyViewModel currencyViewModel = new CurrencyViewModel() { ComparedCurrencies = comparedCur, CurrencyIsBanks = iBankCur, CurrencyYapiKredis = yKBankCur };
            return Ok(currencyViewModel);
        }

    }
}