using System.Collections.Generic;

namespace Exchange.Entity
{
    public interface IExchangeRates
    {
        decimal GetRate(ICurrency currency);
    }
}
