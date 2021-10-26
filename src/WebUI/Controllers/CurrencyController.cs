using CleanArchitecture.Application.Currency.Queries.GetCurrencies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.WebUI.Controllers
{
    public class CurrencyController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Currency>> Get()
        {
            return await Mediator.Send(new GetCurrenciesQuery());
        }
    }
}
