using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;


namespace CleanArchitecture.Application.Currency.Queries.GetCurrencies
{
    public class GetCurrenciesQuery : IRequest<IEnumerable<Currency>>
    {
    }

    public class GetCurrenciesQueryHandler : IRequestHandler<GetCurrenciesQuery, IEnumerable<Currency>>
    {

        public Task<IEnumerable<Currency>> Handle(GetCurrenciesQuery request, CancellationToken cancellationToken)
        {
            List<Currency> currencies = GetAllCurrenciesFromXML();

           // var vm = currencies.Where(x => x.Code == "USD" || x.Code== "EUR");

            return Task.FromResult(currencies.AsEnumerable());
        }

        public List<Currency> GetAllCurrenciesFromXML()
        {
              List<Currency> lstCurrencies = new List<Currency>();
            XmlDocument doc1 = new XmlDocument();
            doc1.Load("http://www.floatrates.com/daily/usd.xml");
            XmlElement root = doc1.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("/response/current_observation");

            string jsonText = JsonConvert.SerializeXmlNode(doc1);
            var result = JsonConvert.DeserializeObject<Root>(jsonText);
            foreach (Item item in result.channel.item)
            {
                var curreny = new Currency();
                curreny.BaseCurrency = item.baseCurrency;
                curreny.BaseName = item.baseName;
                curreny.ExchangeRate = Convert.ToDecimal(item.exchangeRate);
                curreny.TargetCurrency = item.targetCurrency;
                curreny.TargetName = item.targetName;
                curreny.Description = item.description;
                lstCurrencies.Add(curreny);
            }
            return lstCurrencies;
        }
    }
}
