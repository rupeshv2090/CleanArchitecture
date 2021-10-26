using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Currency.Queries.GetCurrencies
{
    public class Currency
    {
        public string BaseCurrency { get; set; }
        public string BaseName { get; set; }
        public string Description { get; set; }
        public decimal ExchangeRate { get; set; }
        public string TargetCurrency { get; set; }
        public string TargetName { get; set; }
    }
}
