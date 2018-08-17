using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyProj.Services
{
  public  interface IEmailNotifier
    {
        void MailSender(string body);
    }
}
