using System;
using System.Collections.Generic;

using Exchange.Entity;

namespace Exchange.Service
{
    public class ExchangeService : IExchangeService
    {
        public decimal CalculateMoneyCurrencyAmount(IExchangeRates exchangeRates, IExchangePair exchangePair)
        {
            if (exchangePair.MainCurrency.Equals(exchangePair.MoneyCurrency)) {
                return exchangePair.Amount;
            }

            try
            {
                decimal mainCurrencyRate = exchangeRates.GetRate(exchangePair.MainCurrency);
                decimal moneyCurrencyRate = exchangeRates.GetRate(exchangePair.MoneyCurrency);
                return (exchangePair.Amount * mainCurrencyRate) / moneyCurrencyRate;
            }
            catch
            {
                // Pass the exception to higher level and handle it there
                throw;
            }
        }
    }
}
