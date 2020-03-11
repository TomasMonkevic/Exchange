using System;
using System.Collections.Generic;

namespace Exchange.Entity
{
    public class ExchangeRates : IExchangeRates
    {
        IExchangeEntityFactory _entityFactory;

        public ExchangeRates(IExchangeEntityFactory factory)
        {
            _entityFactory = factory;
        }
        public ICurrency MainCurrency 
        { 
            get { return _entityFactory.CreateCurrency("Danske kroner", "DKK"); } 
            set { }
        }
        public decimal Unit 
        { 
            get { return 100.0m; }
            set { }
        }
        public Dictionary<ICurrency, decimal> Rates 
        { 
            get 
            {
                return new Dictionary<ICurrency, decimal>() { 
                    { _entityFactory.CreateCurrency("Euro", "EUR"), 743.94m},
                    { _entityFactory.CreateCurrency("Amerikanske dollar", "USD"), 663.11m},
                    { _entityFactory.CreateCurrency("Britiske pund", "GBP"), 852.85m},
                    { _entityFactory.CreateCurrency("Svenske kroner", "SEK"), 76.10m},
                    { _entityFactory.CreateCurrency("Norske kroner", "NOK"), 78.40m},
                    { _entityFactory.CreateCurrency("Schweiziske franc", "CHF"), 683.58m},
                    { _entityFactory.CreateCurrency("Japanske yen", "JPY"), 5.9740m},
                };
            }
            set {}
        }
    }
}
