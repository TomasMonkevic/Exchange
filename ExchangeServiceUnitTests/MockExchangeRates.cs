using System;
using System.Collections.Generic;
using Exchange.Entity;

namespace Exchange.Service.UnitTests
{
    class MockExchangeRates : IExchangeRates
    {
        private Dictionary<ICurrency, decimal> _rates;

        public MockExchangeRates()
        {
            _rates = new Dictionary<ICurrency, decimal>() {
                    { TestData.EUR, 743.94m},
                    { TestData.USD, 663.11m},
                    { TestData.GBP, 852.85m},
             };
        }

        public ICurrency MainCurrency
        {
            get { return TestData.DKK; }
            set { }
        }
        public decimal Unit
        {
            get { return 100.0m; }
            set { }
        }
        public decimal GetRate(ICurrency currency)
        {
            try
            {
                return _rates[currency];
            }
            catch (KeyNotFoundException)
            {
                throw new Exception("Currency not found");
            }
        }
    }
}
