﻿using System;
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
                if (exchangePair.MainCurrency.Equals(exchangeRates.MainCurrency)) {
                    decimal moneyCurrencyRate = exchangeRates.Rates[exchangePair.MoneyCurrency];
                    return (exchangePair.Amount * exchangeRates.Unit) / moneyCurrencyRate;
                }

                if (exchangePair.MoneyCurrency.Equals(exchangeRates.MainCurrency)) {
                    decimal mainCurrencyRate = exchangeRates.Rates[exchangePair.MainCurrency];
                    return (exchangePair.Amount * mainCurrencyRate) / exchangeRates.Unit;
                }
                else
                {
                    decimal mainCurrencyRate = exchangeRates.Rates[exchangePair.MainCurrency];
                    decimal moneyCurrencyRate = exchangeRates.Rates[exchangePair.MoneyCurrency];
                    return (exchangePair.Amount * mainCurrencyRate) / moneyCurrencyRate;
                }
            }
            catch (KeyNotFoundException)
            {
                throw new Exception("Currency not found");
            }
        }
    }
}