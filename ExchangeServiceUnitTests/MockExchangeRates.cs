using System.Collections.Generic;
using Exchange.Entity;

namespace Exchange.Service.UnitTests
{
    class MockExchangeRates : IExchangeRates
    {
        public ICurrency MainCurrency
        {
            get { return TestData.dkk; }
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
                    { TestData.eur, 743.94m},
                    { TestData.usd, 663.11m},
                    { TestData.gbp, 852.85m},
                };
            }
            set { }
        }
    }
}
