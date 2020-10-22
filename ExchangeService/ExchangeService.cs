using System;
using System.Collections.Generic;

using Exchange.Entity;

namespace Exchange.Service
{
    public class ExchangeService : IExchangeService
    {
        private readonly IExchangeRates _exchangeRates;
        public ExchangeService(IExchangeRates exchangeRates)
        {
            _exchangeRates = exchangeRates;
        }
        public decimal CalculateMoneyCurrencyAmount(IExchangePair exchangePair)
        {
            decimal mainCurrencyRate = _exchangeRates.GetRate(exchangePair.MainCurrency);
            decimal moneyCurrencyRate = _exchangeRates.GetRate(exchangePair.MoneyCurrency);
            return (exchangePair.Amount * mainCurrencyRate) / moneyCurrencyRate;
        }
    }
}
