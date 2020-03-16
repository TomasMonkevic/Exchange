using System;
using System.Collections.Generic;

namespace Exchange.Entity
{
    public class ExchangeRates : IExchangeRates
    {
        private IExchangeEntityFactory _entityFactory;
        private Dictionary<ICurrency, decimal> _rates;

        public ExchangeRates(IExchangeEntityFactory factory)
        {
            _entityFactory = factory;
            _rates = new Dictionary<ICurrency, decimal>() {
                    { _entityFactory.CreateCurrency("Danske kroner", "DKK"), 100.0m }, //This is the main currency
                    { _entityFactory.CreateCurrency("Euro", "EUR"), 743.94m},
                    { _entityFactory.CreateCurrency("Amerikanske dollar", "USD"), 663.11m},
                    { _entityFactory.CreateCurrency("Britiske pund", "GBP"), 852.85m},
                    { _entityFactory.CreateCurrency("Svenske kroner", "SEK"), 76.10m},
                    { _entityFactory.CreateCurrency("Norske kroner", "NOK"), 78.40m},
                    { _entityFactory.CreateCurrency("Schweiziske franc", "CHF"), 683.58m},
                    { _entityFactory.CreateCurrency("Japanske yen", "JPY"), 5.9740m},
            };
        }
        public decimal GetRate(ICurrency currency)
        { 
            try
            {
                return _rates[currency];
            }
            catch(KeyNotFoundException)
            {
                throw new Exception("Currency not found");
            }
        }
    }
}
